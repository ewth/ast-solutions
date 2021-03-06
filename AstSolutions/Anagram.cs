﻿using System.Text.RegularExpressions;

namespace AstSolutions
{
    public static class Anagram
    {
        /// <summary>
        /// Check whether two strings are anagrams of each other.
        /// </summary>
        /// <param name="firstString">First string, to check whether is anagram of second</param>
        /// <param name="secondString">Second string, to check whether is anagram of first</param>
        /// <returns>True if two strings are anagrams, False otherwise</returns>
        /// <remarks>Only Latin alphabetical characters are considered.</remarks>
        /// <remarks>Stings are treated as case insensitive.</remarks>
        /// <remarks>The algorithm is based on [ http://javabypatel.blogspot.com/2015/10/check-strings-are-anagrams.html ]</remarks>
        public static bool IsAnagram(string firstString, string secondString)
        {

            // First implementation is to be case insensitive but leaving this here in case it changes and can become a paramater.
            bool caseInsensitive = true;

            // If case sensitive, convert to lowercase for simplicity
            if (caseInsensitive)
            {
                firstString = firstString.ToLower();
                secondString = secondString.ToLower();
            }

            // Replace non-alphabet characters... is this cheating?
            firstString = Regex.Replace(firstString, "[^a-z]", "");
            secondString = Regex.Replace(secondString, "[^a-z]", "");

            var firstCharacterCount = CharacterCount(firstString);
            var secondCharacterCount = CharacterCount(secondString);

            // @todo: this is a very hacky comparison, maybe find a better way
            for (var i = 0; i < firstCharacterCount.Length; i++)
            {
                if (firstCharacterCount[i] != secondCharacterCount[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Simple method to track which alphabet characters are used within a string.
        /// </summary>
        /// <param name="inputString">String to check</param>
        /// <returns>int[26] array of characters and how many times they are used</returns>
        private static int[] CharacterCount(string inputString)
        {
            var characterCount = new int[26];
            var ordinalA = (byte) 'a';
            for (var i = 0; i < inputString.Length; i++)
            {
                characterCount[(byte) inputString[i] - ordinalA]++;
            }

            return characterCount;

        }
    }
}
