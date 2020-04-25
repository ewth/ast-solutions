using AstSolutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AstSolutionsTests
{
    [TestClass]
    public class PhoneNumberTests
    {

        [TestMethod]
        public void PhoneNumber_CheckBasicValidPhoneNumber_ShouldReturnTrue()
        {
            // Arrange
            var phoneNumber = "0412123123";

            // Act
            var isValid = PhoneNumber.IsValidPhonenumber(phoneNumber);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void PhoneNumber_CheckBasicInvalidPhoneNumberNoLeadingZero_ShouldReturnFalse()
        {
            // Arrange
            var phoneNumber = "412123123";

            // Act
            var isValid = PhoneNumber.IsValidPhonenumber(phoneNumber);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void PhoneNumber_CheckBasicInvalidPhoneNumberNoFour_ShouldReturnFalse()
        {
            // Arrange
            var phoneNumber = "0812123123";

            // Act
            var isValid = PhoneNumber.IsValidPhonenumber(phoneNumber);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void PhoneNumber_CheckFormattedValidPhoneNumber_ShouldReturnTrue()
        {
            // Arrange
            var phoneNumber = "0412 123 123";

            // Act
            var isValid = PhoneNumber.IsValidPhonenumber(phoneNumber);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void PhoneNumber_CheckFormattedDashesValidPhoneNumber_ShouldReturnTrue()
        {
            // Arrange
            var phoneNumber = "0412-123-123";

            // Act
            var isValid = PhoneNumber.IsValidPhonenumber(phoneNumber);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void PhoneNumber_CheckPoorlyFormattedButValidNumber_ShouldReturnTrue()
        {
            // Arrange
            var phoneNumber = "041 212 312 3";

            // Act
            var isValid = PhoneNumber.IsValidPhonenumber(phoneNumber);

            // Assert
            Assert.IsTrue(isValid);
        }


        [TestMethod]
        public void PhoneNumber_CheckFormattedInternationalPhoneNumberWithPlus_ShouldReturnTrue()
        {
            // Arrange
            var phoneNumber = "+61412123123";

            // Act
            var isValid = PhoneNumber.IsValidPhonenumber(phoneNumber);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void PhoneNumber_CheckFormattedInternationalPhoneNumberWithPlusAndZero_ShouldReturnTrue()
        {
            // Arrange
            var phoneNumber = "+610412123123";

            // Act
            var isValid = PhoneNumber.IsValidPhonenumber(phoneNumber);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void PhoneNumber_CheckFormattedInternationalPhoneNumberWithoutPlus_ShouldReturnTrue()
        {
            // Arrange
            var phoneNumber = "61412123123";

            // Act
            var isValid = PhoneNumber.IsValidPhonenumber(phoneNumber);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void PhoneNumber_CheckInternationalBadPhoneNumberNoFour_ShouldReturnFalse()
        {
            // Arrange
            var phoneNumber = "+61112123123";

            // Act
            var isValid = PhoneNumber.IsValidPhonenumber(phoneNumber);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void PhoneNumber_CheckInternationalBadPhoneNumberNotAuDialingCode_ShouldReturnFalse()
        {
            // Arrange
            var phoneNumber = "+62412123123";

            // Act
            var isValid = PhoneNumber.IsValidPhonenumber(phoneNumber);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void PhoneNumber_CheckBadPhoneNumberTooManyDigits_ShouldReturnFalse()
        {
            // Arrange
            var phoneNumber = "04121231231";

            // Act
            var isValid = PhoneNumber.IsValidPhonenumber(phoneNumber);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void PhoneNumber_CheckBadPhoneNumberInternationalTooManyDigits_ShouldReturnFalse()
        {
            // Arrange
            var phoneNumber = "+6104121231231";

            // Act
            var isValid = PhoneNumber.IsValidPhonenumber(phoneNumber);

            // Assert
            Assert.IsFalse(isValid);
        }

    }
}