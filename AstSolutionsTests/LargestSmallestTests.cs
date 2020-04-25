using System.IO.Enumeration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AstSolutions;

namespace AstSolutionsTests
{
    [TestClass]
    public class LargestSmallestTests
    {
        [TestMethod]
        public void FindLargestSmallest_ClassCreated_InstantiatedValuesCorrect()
        {
            // Arrange
            var smallest = 3;
            var largest = 5;

            // Act
            var largestSmallest = new InterestingParts.LargestSmallest(largest, smallest);

            // Assert
            Assert.AreEqual(smallest, largestSmallest.Smallest);
            Assert.AreEqual(largest, largestSmallest.Largest);
            Assert.AreNotEqual(largest, largestSmallest.Smallest);
            Assert.AreNotEqual(smallest, largestSmallest.Largest);
        }

        [TestMethod]
        public void FindLargestSmallest_NumbersPassedMethod1_CorrectValuesReturned()
        {

            // Arrange
            var numbers = string.Join("\r\n", new[] {"1", "3", "5"});

            // Act
            var result = InterestingParts.FindLargestSmallest(numbers, 1);

            // Assert
            Assert.AreEqual(1, result.Smallest);
            Assert.AreEqual(5, result.Largest);
        }

        [TestMethod]
        public void FindLargestSmallest_NumbersPassedMethod2_CorrectValuesReturned()
        {

            // Arrange
            var numbers = string.Join("\r\n", new[] { "1", "3", "5" });

            // Act
            var result = InterestingParts.FindLargestSmallest(numbers, 2);

            // Assert
            Assert.AreEqual(1, result.Smallest);
            Assert.AreEqual(5, result.Largest);
        }

        [TestMethod]
        public void FindLargestSmallest_NumbersPassedMethod3_CorrectValuesReturned()
        {

            // Arrange
            var numbers = string.Join("\r\n", new[] { "1", "3", "5" });

            // Act
            var result = InterestingParts.FindLargestSmallest(numbers, 3);

            // Assert
            Assert.AreEqual(1, result.Smallest);
            Assert.AreEqual(5, result.Largest);
        }

        [TestMethod]
        public void FindLargestSmallest_NumbersPassedNoMethod_CorrectValuesReturned()
        {

            // Arrange
            var numbers = string.Join("\r\n", new[] { "1", "3", "5" });

            // Act
            var result = InterestingParts.FindLargestSmallest(numbers);

            // Assert
            Assert.AreEqual(1, result.Smallest);
            Assert.AreEqual(5, result.Largest);
        }

        [TestMethod]
        public void FindLargestSmallest_NumbersPassedWithSomeInvalid_CorrectValuesReturned()
        {

            // Arrange
            var numbers = string.Join("\r\n", new[] { "a1", "3", "5" });

            // Act
            var result = InterestingParts.FindLargestSmallest(numbers);

            // Assert
            Assert.AreEqual(3, result.Smallest);
            Assert.AreEqual(5, result.Largest);
        }

        [TestMethod]
        public void FindLargestSmallest_NoNumbersPassed_ExceptionThrown()
        {

            // Arrange
            var numbers = string.Join("\r\n", new[] { "a1", "b3", "c5" });

            // Act
            try
            {
                var result = InterestingParts.FindLargestSmallest(numbers);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.ParamName, "numbersOnePerLine");
                return;
            }

            Assert.Fail("Expected exception not thrown.");
        }


    }
}
