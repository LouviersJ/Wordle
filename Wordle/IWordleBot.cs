using System;
using System.Collections.Generic;
using System.IO;

namespace Wordle
{
	public interface IWordleBot
	{
        public List<GuessResult> Guesses { get; set; }

        public string GenerateGuess();


        public bool IsValidWord(string word)
        {
            string text = System.IO.File.ReadAllText(@"..\..\..\data\english_words_full.txt");

            return text.Contains(word.ToLower());
        }

    }
}