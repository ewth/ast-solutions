using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstSolutions
{
    public class LargestSmallest
    {

        /// <summary>
        /// Simple class to hold result of finding largest/smallest number (q#1)
        /// </summary>
        /// <remarks>Instinctively I'd go smallest...largest, but the question explicitly words it "largest to smallest"</remarks>
        public class LargestSmallestCollection
        {
            public int Largest { get; }
            public int Smallest { get; }

            public LargestSmallestCollection(int largest, int smallest)
            {
                Largest = largest;
                Smallest = smallest;
            }

        }

        /// <summary>
        /// Simple method to find the smallest and largest numbers in a set.
        /// </summary>
        /// <param name="numbersOnePerLine">String of numbers separated by newlines</param>
        /// <param name="method"></param>
        /// <returns>LargestSmallestCollection instantiated with largest and smallest value from list</returns>
        public static LargestSmallestCollection FindLargestSmallest(string numbersOnePerLine, int method = 1)
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
                    return new LargestSmallestCollection(numbers.Max(), numbers.Min());

                // Method 2: Iterate (gross)
                case 2:
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
                    return new LargestSmallestCollection( maxNumber, minNumber);

                // Method 3: LINQ
                case 3:
                    var largest = numbers.OrderByDescending(number => number).First();
                    var smallest = numbers.OrderBy(number => number).First();
                    return new LargestSmallestCollection(largest, smallest);

                // Default is fallback to method 1.
                // It feels correct...erer to stack case 1 and default, but then it reads case 2, case 3, case 1 and looks naff.
                default:
                    return new LargestSmallestCollection(numbers.Max(), numbers.Min());
            }
        }
    }
}
