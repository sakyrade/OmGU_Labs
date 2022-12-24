using Lab_1.regex_strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.menu_tasks
{
    public delegate void StringsTaskHandler(string message);
    public class StringsTask : Task
    {
        public event StringsTaskHandler? OnCheckCompleted;
        public event TaskStartingHandler? OnTaskStarting;
        public string FirstString { get; private set; }
        public string SecondString { get; private set; }
        public StringsTask() { }
        public StringsTask(StringsTaskHandler? checkHandler,
                           TaskStartingHandler? startHandler, string[] args = null) 
        {
            Title = "Strings";
            OnCheckCompleted += checkHandler;
            OnTaskStarting += startHandler;
            Args = args;
        }
        public override void Execute()
        {
            OnTaskStarting?.Invoke(this);

            OnCheckCompleted?.Invoke(CheckEqual(FirstString, SecondString));

            FirstString = NormalizeString(FirstString);
            SecondString = NormalizeString(SecondString);

            OnCheckCompleted?.Invoke($"Normalize first string: {FirstString}.");
            OnCheckCompleted?.Invoke($"Normalize first string: {SecondString}.");

            OnCheckCompleted?.Invoke(CheckEqual(FirstString, SecondString));

            OnCheckCompleted?.Invoke(CheckReverse(FirstString, SecondString));

            List<RegexValidator> regexValidators = new()
            {
                { new EmailRegexString() },
                { new PhoneNumberRegexString() },
                { new IPv4AddressRegexString() },
                { new IPv6AddressRegexString() }
            };

            string[] inputStrings = new string[]
            {
                FirstString,
                SecondString
            };

            foreach (var regexValidator in regexValidators)
                foreach (string str in inputStrings)
                    OnCheckCompleted?.Invoke(CheckRegex(str, regexValidator));
        }
        public void Init(string firstString, string secondString)
        {
            FirstString = firstString;
            SecondString = secondString;
        }
        private static string CheckEqual(string firstString, string secondString)
        {
            try
            {
                IsEqual(firstString, secondString);
                return $"{firstString} and {secondString} is equal.";
            }
            catch (ValidationException validException)
            {
                return validException.Message;
            }
        }
        private static string CheckReverse(string firstString, string secondString)
        {
            try
            {
                IsReverse(firstString, secondString);
                return $"{firstString} is reverse {secondString}.";
            }
            catch (ValidationException validException)
            {
                return validException.Message;
            }
        }
        private static string CheckRegex(string str, RegexValidator regexValidator)
        {
            try
            {
                IsRegexValid(str, regexValidator);
                return str + " is " + regexValidator.ToString() + '.';
            }
            catch (ValidationException validException)
            {
                return validException.Message;
            }
        }
        public static string Reverse(string str)
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
