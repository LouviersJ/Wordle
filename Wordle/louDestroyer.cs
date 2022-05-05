using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Wordle
{
	public class louDestroyer : IWordleBot
	{
		public louDestroyer()
		{
		}

        public static string[] text = System.IO.File.ReadAllLines(@"..\..\..\data\english_words_10k_mit.txt");
        public static string[] remainingWords = Array.FindAll(text, x => x.Length == 5);
        public List<GuessResult> Guesses { get; set; } = new List<GuessResult>();
        public string newWord = "";
        public List<string> guessList { get; set; } = new List<string>(remainingWords.ToList());

        public string GenerateGuess()
        {
            if (newWord == "") {
                newWord = remainingWords[0];
                return "dealt";
            }
            string oldWord = Guesses[^1].ToString();
            for (int i = 0; i <= 5; i++)
            {
                if (oldWord[i+6] == 'C')
                    guessList.RemoveAll(x => x[i] != newWord[i]);
                if (oldWord[i+6] == 'I')
                    guessList.RemoveAll(x => x.Contains(newWord[i]));
                if (oldWord[i+6] == 'M')
                    guessList.RemoveAll(x => !(x.Contains(newWord[i])));
            }

            newWord = guessList.Last();
            return newWord;
        }
    }
}
