using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.safe_readers
{
    static class ReadStrings
    {
        public static string ReadString(string message)
        {
            Console.Clear();
            Console.Write(message);

            string? inputLine = Console.ReadLine();

            if (string.IsNullOrEmpty(inputLine) || string.IsNullOrWhiteSpace(inputLine))
            {
                throw new ValidationException($"{inputLine} is incorrect.");
                Console.ReadKey();
                return ReadString(message);
            }

            return inputLine;
        }
    }
}
