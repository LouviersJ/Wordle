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
        public string[] remainingWords = Array.FindAll(text, x => x.Length == 5);
        public List<GuessResult> Guesses { get; set; }
        public string newWord = "";
        
        public string GenerateGuess()
        {
            if (newWord == "") {
                newWord = remainingWords[0];
                return "dealt";
            }
            
            string oldWord = Guesses[^1].ToString();
            List<string> guessList = new List<string>();
            for (int i = 0; i <= 5; i++)
            {
                if (oldWord[i+6] == 'C')
                    guessList = (List<string>)remainingWords.Where(x => x[i] == newWord[i]);
                if (oldWord[i+6] == 'I')
                    guessList = (List<string>)remainingWords.Where(x => !(x.Contains(newWord[i])));
                if (oldWord[i+6] == 'M')
                    guessList = (List<string>)remainingWords.Where(x => x.Contains(newWord[i]));
            }
            remainingWords = guessList.ToArray();
            newWord = guessList[0];
            return newWord;
        }
    }
}
