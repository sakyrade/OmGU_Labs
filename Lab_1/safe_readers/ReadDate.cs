using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.safe_readers
{
    static class ReadDate
    {
        public static (DateOnly, DateOnly) Read(string message)
        {
            Console.WriteLine(message);

            DateOnly firstDate = ReadDateOnly("First date: ");
            DateOnly secondDate = ReadDateOnly("Second date: ");

            if (secondDate <= firstDate)
            {
                Console.WriteLine("The first date cannot be less than or equal to the second date.");
                Console.ReadKey();
                Console.Clear();

                return Read(message);
            }

            return (firstDate, secondDate);
        }

        private static DateOnly ReadDateOnly(string message)
        {
            Console.Write(message);

            string? inputLine = Console.ReadLine();

            if (DateOnly.TryParse(inputLine, out DateOnly date)) return date;

            Console.WriteLine($"{inputLine} is incorrect.");
            Console.ReadKey();
            Console.Clear();

            return ReadDateOnly(message);
        }
    }
}
