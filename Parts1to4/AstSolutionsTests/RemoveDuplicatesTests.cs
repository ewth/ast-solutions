using AstSolutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AstSolutionsTests
{
    [TestClass]
    public class RemoveDuplicatesTests
    {
        [TestMethod]
        public void RemoveDuplicates_RemoveDuplicatesFromStringUsingDefaultMethod_DuplicatesRemoved()
        {
            // Arrange
            var startingString = "AABBCC,ABC,D";
            var expectedString = "ABC,D";

            // Act
            var result = RemoveDuplicates.RemoveDuplicatesFromString(startingString);

            // Assert
            Assert.AreEqual(expectedString, result);
        }

        [TestMethod]
        public void RemoveDuplicates_RemoveDuplicatesFromStringUsingMethod1_DuplicatesRemoved()
        {
            // Arrange
            var startingString = "AABBCC,ABC,D";
            var expectedString = "ABC,D";

            // Act
            var result = RemoveDuplicates.RemoveDuplicatesFromString(startingString, 1);

            // Assert
            Assert.AreEqual(expectedString, result);
        }

        [TestMethod]
        public void RemoveDuplicates_RemoveDuplicatesFromStringUsingMethod2_DuplicatesRemoved()
        {
            // Arrange
            var startingString = "AABBCC,ABC,D";
            var expectedString = "ABC,D";

            // Act
            var result = RemoveDuplicates.RemoveDuplicatesFromString(startingString, 2);

            // Assert
            Assert.AreEqual(expectedString, result);
        }

        [TestMethod]
        public void RemoveDuplicates_RemoveDuplicatesFromStringUsingMethod3_DuplicatesRemoved()
        {
            // Arrange
            var startingString = "AABBCC,ABC,D";
            var expectedString = "ABC,D";

            // Act
            var result = RemoveDuplicates.RemoveDuplicatesFromString(startingString, 3);

            // Assert
            Assert.AreEqual(expectedString, result);
        }
    }
}