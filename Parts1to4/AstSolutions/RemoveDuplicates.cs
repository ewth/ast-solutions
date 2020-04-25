using System;
using System.Linq;
using System.Text;

namespace AstSolutions
{
    public class RemoveDuplicates
    {
        /// <summary>
        /// Process a provided input string to remove any duplicate characters from
        /// </summary>
        /// <param name="inputString">Input string to remove duplicate characters from.</param>
        /// <param name="method">Method to use, defaults to 1</param>
        /// <returns>String with duplicate characters removed</returns>
        public static string RemoveDuplicatesFromString(string inputString, int method = 1)
        {
            switch (method)
            {
                case 1:
                    return RemoveDuplicatesMethod1(inputString);
                case 2:
                    return RemoveDuplicatesMethod2(inputString);
                case 3:
                    return RemoveDuplicatesMethod3(inputString);
                default:
                    throw new NotImplementedException($"There is no method {method}");
            }
        }

        /// <summary>
        /// Method 1: Use a combination of LINQ and string.Join()
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        /// <remarks>The best way, in my opinion, as it is no less efficient than other methods (more so than some), and requires minimal code.</remarks>
        private static string RemoveDuplicatesMethod1(string inputString)
        {
            return string.Join("", inputString.Distinct().ToArray());
        }


        /// <summary>
        /// Method 2: The most spartan way of doing it, simply iterating over string and adding character if it doesn't already appear in result.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private static string RemoveDuplicatesMethod2(string inputString)
        {
            var outputString = "";

            foreach (var character in inputString)
            {
                if (!outputString.Contains(character))
                {
                    outputString += character;
                }
            }

            return outputString;
        }

        /// <summary>
        /// Method 3: Uses an int array to track used ASCII characters and a string builder to store the result.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>String stripped of duplicate characters</returns>
        private static string RemoveDuplicatesMethod3(string inputString)
        {
            var usedCharacters = new int[256];
            var outputString = new StringBuilder();
            foreach (var character in inputString)
            {
                var ordinal = (byte) character;

                if (usedCharacters[ordinal] != 1)
                {
                    usedCharacters[ordinal] = 1;
                    outputString.Append(character);
                }
            }

            return outputString.ToString();
        }
        
    }
}
