using System;
using System.Collections.Generic;

namespace AoC.Day5
{
    /// <summary>
    /// --- Day 5: Doesn't He Have Intern-Elves For This? ---
    /// </summary>
    public class Solution : AbstractSolution
    {
        private const string vowels = "aeiou";
        private readonly List<string> bannedWords = new List<string> { "ab", "cd", "pq", "xy" };

        public override void Run()
        {
            var lines = System.IO.File.ReadAllLines(@"Day-5/Input.txt");

            var niceFirst = 0;
            var niceSecond = 0;

            foreach (var line in lines)
            {
                if (CountVowels(line) >= 3 && ContainsDups(line) && ContainsNoBannedWords(line))
                {
                    niceFirst += 1;
                }

                if (ContainsPair(line) && ContaintLetterBetween(line))
                {
                    niceSecond += 1;
                }
            }

            Console.WriteLine($"First part: {niceFirst}");
            Console.WriteLine($"Second part: {niceSecond}");
        }

        private int CountVowels(string input)
        {
            var n = 0;

            foreach (var ch in input)
            {
                if (vowels.Contains($"{ch}"))
                {
                    n += 1;
                }
            }

            return n;
        }

        private bool ContainsDups(string input)
        {
            for (var i = 0; i < input.Length - 1; ++i)
            {
                if (input[i] == input[i + 1])
                {
                    return true;
                }
            }

            return false;
        }

        private bool ContainsNoBannedWords(string input)
        {
            foreach (var word in bannedWords)
            {
                if (input.Contains(word))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ContainsPair(string input)
        {
            for (var i = 0; i < input.Length - 2; ++i)
            {
                if (input.Substring(i + 2).Contains($"{input[i]}{input[i + 1]}"))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ContaintLetterBetween(string input)
        {
            for (var i = 0; i < input.Length - 2; ++i)
            {
                if (input[i] == input[i + 2])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
