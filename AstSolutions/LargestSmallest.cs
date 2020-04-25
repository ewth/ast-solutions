using System;
using System.Linq;

namespace AstSolutions
{
    public class LargestSmallest
    {

        /// <summary>
        /// Simple class to hold result of finding largest/smallest number (q#1)
        /// </summary>
        /// <remarks>Instinctively I'd go smallest...largest, but the question explicitly words it "largest to smallest"</remarks>
        public class LargestSmallestResult
        {
            public int Largest { get; }
            public int Smallest { get; }

            public LargestSmallestResult(int largest, int smallest)
            {
                Largest = largest;
                Smallest = smallest;
            }

        }

        /// <summary>
        /// Simple method to find the smallest and largest numbers in a set.
        /// </summary>
        /// <param name="numbersOnePerLine">String of numbers separated by newlines</param>
        /// <param name="method">Method to use (1, 2, or 3), defaults to 1</param>
        /// <returns>LargestSmallestResult instantiated with largest and smallest value from list</returns>
        public static LargestSmallestResult FindLargestSmallest(string numbersOnePerLine, int method = 1)
        {

            // Wouldn't be necessary if we knew everyone is using Windows... but we don't, so my paranoia is justified
            numbersOnePerLine = numbersOnePerLine.Replace("\r\n", "\n");

            // Get numbers first; discard non-numbers.
            // Using LINQ for simplicity.
            var numbers = numbersOnePerLine
                .Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Where(number => int.TryParse(number, out _))
                .Select<string, int>(int.Parse)
                .ToArray();

            if (numbers.Length < 1)
            {
                throw new ArgumentOutOfRangeException("numbersOnePerLine", "No valid integers were found in the provided values. Please check them and try again.");
            }

            // Three methods are used here.
            // This is just to demonstrate possible ways it could be done.
            // It's not intended to be comprehensive, but rather to demonstrate that I am aware there are multiple approaches to a simple problem.
            
            switch (method)
            {
                // Method 1: Array.Min(), Array.Max() (default fallback)
                case 1:
                    return LargestSmallestMethod1(numbers);

                // Method 2: Iterate (gross)
                case 2:
                    return LargestSmallestMethod2(numbers);

                // Method 3: LINQ
                case 3:
                    return LargestSmallestMethod1(numbers);

                default:
                    throw new NotImplementedException($"There is no method {method}.");
            }
        }

        /// <summary>
        /// Find largest and smallest using simple array methods
        /// </summary>
        /// <param name="numbers">Integer array of numbers</param>
        /// <returns>Instantiated LargestSmallestResult class with resutls</returns>
        private static LargestSmallestResult LargestSmallestMethod1(int[] numbers)
        {
            return new LargestSmallestResult(numbers.Max(), numbers.Min());
        }

        /// <summary>
        /// Find largest and smallest by iterating over array and comparing entries
        /// </summary>
        /// <param name="numbers">Integer array of numbers</param>
        /// <returns>Instantiated LargestSmallestResult class with resutls</returns>
        private static LargestSmallestResult LargestSmallestMethod2(int[] numbers)
        {
            int maxNumber = 0, minNumber = 0;
            for (var i = 0; i < numbers.Length; i++)
            {
                var number = numbers[i];
                // Init first time
                if (i == 0)
                {
                    maxNumber = number;
                    minNumber = number;
                }
                else
                {
                    maxNumber = Math.Max(maxNumber, number);
                    minNumber = Math.Min(minNumber, number);
                }
            }
            return new LargestSmallestResult(maxNumber, minNumber);

        }

        /// <summary>
        /// Find largest and smallest by using LINQ to order the values in appropriate direction and taking first result
        /// </summary>
        /// <param name="numbers">Integer array of numbers</param>
        /// <returns>Instantiated LargestSmallestResult class with resutls</returns>
        private static LargestSmallestResult LargestSmallestMethod3(int[] numbers)
        {
            var largest = numbers.OrderByDescending(number => number).First();
            var smallest = numbers.OrderBy(number => number).First();
            return new LargestSmallestResult(largest, smallest);
        }
    }
}
