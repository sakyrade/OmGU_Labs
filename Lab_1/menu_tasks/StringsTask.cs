using Lab_1.regex_strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.menu_tasks
{
    class StringsTask : Task
    {
        public StringsTask() => Title = "Strings";

        public override void Execute()
        {
            string firstString = safe_readers.ReadStrings.ReadString("Input first string: ");
            string secondString = safe_readers.ReadStrings.ReadString("Input second string: ");

            Console.WriteLine("----------- Strings Analysis -----------\n");

            CheckEqual(firstString, secondString);

            firstString = StringWorker.NormalizeString(firstString);
            secondString = StringWorker.NormalizeString(secondString);

            Console.WriteLine($"Normalize first string: {firstString}.");
            Console.WriteLine($"Normalize second string: {secondString}.\n");

            CheckEqual(firstString, secondString);

            CheckReverse(firstString, secondString);

            List<RegexValidator> regexValidators = new List<RegexValidator>()
            {
                { new EmailRegexString() },
                { new PhoneNumberRegexString() },
                { new IPv4AddressRegexString() },
                { new IPv6AddressRegexString() }
            };

            string[] inputStrings = new string[]
            {
                firstString,
                secondString
            };

            foreach (var regexValidator in regexValidators)
            {
                for (int i = 0; i < 2; i++)
                {
                    try
                    {
                        StringWorker.IsRegexValid(inputStrings[i], regexValidator);
                        Console.WriteLine(inputStrings[i] + " is " + regexValidator.ToString() + '.');
                    }
                    catch (ValidationException validException)
                    {
                        Console.WriteLine(validException.Message);
                    }
                }
            }
        }

        private void CheckEqual(string firstString, string secondString)
        {
            try
            {
                StringWorker.IsEqual(firstString, secondString);
                Console.WriteLine($"{firstString} and {secondString} is equal.");
            }
            catch (ValidationException validException)
            {
                Console.WriteLine(validException.Message);
            }
        }
        private void CheckReverse(string firstString, string secondString)
        {
            try
            {
                StringWorker.IsReverse(firstString, secondString);
                Console.WriteLine($"{firstString} is reverse {secondString}.");
            }
            catch (ValidationException validException)
            {
                Console.WriteLine(validException.Message);
            }
        }
    }
}
