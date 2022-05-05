using System;
using System.IO;

namespace Wordle
{
	public class WordleGame
	{
		public string SecretWord { get; set; }
		public int MaxGuesses { get; set; } = 100;

		public WordleGame(string secretWord = "arise")
		{
			SecretWord = secretWord;
		}

		public int Play(IWordleBot bot)
		{
			int guessNumber;
			for (guessNumber = 1; guessNumber < MaxGuesses; guessNumber++)
			{
				string guess = bot.GenerateGuess();
				Console.WriteLine($"guess {guessNumber}: {guess}");

				GuessResult guessResult = CheckGuess(guess);
				bot.Guesses.Add(guessResult);
				Console.WriteLine(guessResult);

				if (IsCorrect(guessResult))
				{
					return guessNumber;
				}
			}

			return guessNumber;
		}

		// TODO
		public GuessResult CheckGuess(string guess)
        {
			GuessResult _guess = new GuessResult(guess);
			for (int i= 0; i< SecretWord.Length; i++)
            {
				if (guess[i].Equals(SecretWord[i]))
					_guess.Guess[i].LetterResult = LetterResult.Correct;
				else if (SecretWord.Contains(guess[i]))
					_guess.Guess[i].LetterResult = LetterResult.Misplaced;
			}

			return _guess;
        }
		private bool IsCorrect(GuessResult guessResult)
        {
			foreach(var letterGuess in guessResult.Guess)
			{
				if (letterGuess.LetterResult != LetterResult.Correct)
					return false;
			}
			return true;
        }
	}
}

