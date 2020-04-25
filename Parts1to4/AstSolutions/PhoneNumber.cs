using System.Text.RegularExpressions;

namespace AstSolutions
{
    public static class PhoneNumber
    {

        /// <summary>
        /// Validate an Australian mobile phone number using a regular expression.
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>True if valid, False otherwise</returns>
        /// <remarks>The string is sanitised first so formatting doesn't become an issue. E.g. "0412 123 123", "0412123123", "04 12 12 3 1 2 3" are all valid phone numbers, even if the formatting is horrible.</remarks>
        /// <remarks>+61412123123 is valid but +610412123123 is considered invalid. Although I've seen customer records with numbers as "+6104" it's not technically correct, and thus fails validation here.</remarks>
        public static bool IsValidPhonenumber(string phoneNumber)
        {

            // Develop regex to match valid phone number
            // Remove any spaces or dashes from the phone number
            phoneNumber = Regex.Replace(phoneNumber, "[- ]", "");
            return Regex.IsMatch(phoneNumber, "^(([+]?614)|04)([0-9]{8,8})$");
        }
    }
}
