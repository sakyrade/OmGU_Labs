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

            bool isEqual = StringWorker.IsEqual(firstString, secondString, out string? messageIsEqual);

            Console.WriteLine(messageIsEqual + '\n');

            if (isEqual)
            {
                firstString = StringWorker.NormalizeString(firstString);
                secondString = StringWorker.NormalizeString(secondString);

                Console.WriteLine($"Normalize first string: {firstString}.");
                Console.WriteLine($"Normalize second string: {secondString}.\n");
            }

            Console.WriteLine(StringWorker.IsReverse(firstString, secondString) + '\n');

            Console.WriteLine(StringWorker.IsRegexValid(firstString, new EmailRegexString()));
            Console.WriteLine(StringWorker.IsRegexValid(secondString, new EmailRegexString()) + '\n');
            Console.WriteLine(StringWorker.IsRegexValid(firstString, new PhoneNumberRegexString()));
            Console.WriteLine(StringWorker.IsRegexValid(secondString, new PhoneNumberRegexString()) + '\n');
            Console.WriteLine(StringWorker.IsRegexValid(firstString, new IPv4AddressRegexString()));
            Console.WriteLine(StringWorker.IsRegexValid(secondString, new IPv4AddressRegexString()) + '\n');
            Console.WriteLine(StringWorker.IsRegexValid(firstString, new IPv6AddressRegexString()));
            Console.WriteLine(StringWorker.IsRegexValid(secondString, new IPv6AddressRegexString()));
        }
    }
}
