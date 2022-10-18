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
        public static bool IsEqual(string firstString, string secondString, out string? message)
        {
            message = $"{firstString} is not equal {secondString}.";

            if (firstString.Equals(secondString, StringComparison.CurrentCulture))
            {
                message = $"{firstString} is equal {secondString}.";
                return true;
            }

            return false;
        }
        public static string IsReverse(string firstString, string secondString)
        {
            if (Reverse(firstString).Equals(secondString, StringComparison.CurrentCulture)) return $"{firstString} is a reverse {secondString}.";
            return $"{firstString} is not reverse {secondString}.";
        }
        public static string NormalizeString(string str) => str.ToLower().Trim().Replace("  ", " ");
        public static string IsRegexValid(string str, IRegexString regexString)
        {
            if (Regex.IsMatch(str, regexString.RegexString)) return str + regexString.SuccessMessage;
            return str + regexString.FailureMessage;
        }
    }
}
