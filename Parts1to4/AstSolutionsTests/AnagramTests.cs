using AstSolutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AstSolutionsTests
{
    [TestClass]
    public class AnagramTests
    {

        [TestMethod] public void IsAnagram_CheckAnagram_ShouldReturnTrue()
        {
            // Arrange
            var firstString = "rail safety";
            var secondString = "fairy tales";

            // Act
            var isAnagram = Anagram.IsAnagram(firstString, secondString);

            // Assert
            Assert.IsTrue(isAnagram);
        }

        [TestMethod]
        public void IsAnagram_CheckNotAnAnagram_ShouldReturnFalse()
        {
            // Arrange
            var firstString = "rail safety";
            var secondString = "this is certainly not an anagram";

            // Act
            var isAnagram = Anagram.IsAnagram(firstString, secondString);

            // Assert
            Assert.IsFalse(isAnagram);
        }

        [TestMethod]
        public void IsAnagram_CheckAnagramWithNonAlphabetCharacters_ShouldReturnTrue()
        {
            // Arrange
            var firstString = "r!ail.sa#fety!";
            var secondString = "fa&iry-ta4les?";

            // Act
            var isAnagram = Anagram.IsAnagram(firstString, secondString);

            // Assert
            Assert.IsTrue(isAnagram);
        }

        [TestMethod]
        public void IsAnagram_CheckAnagramWithMixedCase_ShouldReturnTrue()
        {
            // Arrange
            var firstString = "RaIl SafEtY";
            var secondString = "fairy TALES";

            // Act
            var isAnagram = Anagram.IsAnagram(firstString, secondString);

            // Assert
            Assert.IsTrue(isAnagram);
        }


    }
}