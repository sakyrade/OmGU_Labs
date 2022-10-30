using Lab_1.regex_strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_1
{
    static class StringWorker
    {
        private static string Reverse(string str)
        {
            StringBuilder reverseStringBuilder = new StringBuilder();

            for (int i = str.Length - 1; i >= 0; i--)
                reverseStringBuilder.Append(str[i]);

            return reverseStringBuilder.ToString();
        }
        public static void IsEqual(string firstString, string secondString)
        {
            if (!firstString.Equals(secondString, StringComparison.CurrentCulture))
                throw new ValidationException($"{firstString} is not equal {secondString}.");
        }
        public static void IsReverse(string firstString, string secondString)
        {
            if (!Reverse(firstString).Equals(secondString, StringComparison.CurrentCulture))
                throw new ValidationException($"{firstString} is not reverse {secondString}.");
        }
        public static string NormalizeString(string str) => str.ToLower().Trim().Replace("  ", " ");
        public static void IsRegexValid(string str, RegexValidator regexValidator)
        {
            if (!regexValidator.IsValid(str))
                throw new ValidationException(str + " is not " + regexValidator.ToString() + '.');
        }
    }
}
