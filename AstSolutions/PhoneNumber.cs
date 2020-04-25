﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        /// <remarks>+61412123123 and +610412123123 are considered valid representations of the phone number. +6104 may not be "technically" valid but is how users sometimes enter phone numbers, from experience.</remarks>
        public static bool IsValidPhonenumber(string phoneNumber)
        {

            // Develop regex to match valid phonenumber
            // Restrict phone number to only numbers and +
            phoneNumber = Regex.Replace(phoneNumber, "[^0-9+]", "");
            return Regex.IsMatch(phoneNumber, "(([+]?(614|6104))|04)([0-9]{8,8})");
        }
    }
}
