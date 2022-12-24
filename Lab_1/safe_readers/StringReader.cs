using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.safe_readers
{
    static class StringReader
    {
        public static string Read(string message)
        {
            Console.Write(message);

            string? inputLine = Console.ReadLine();

            try
            {
                if (string.IsNullOrEmpty(inputLine) || string.IsNullOrWhiteSpace(inputLine))
                    throw new ValidationException($"{inputLine} is incorrect.");

                return inputLine;
            }
            catch (ValidationException validationException)
            {
                Console.WriteLine(validationException.Message);
                Console.ReadKey();
                Console.Clear();
                return Read(message);
            }
        }
    }
}
