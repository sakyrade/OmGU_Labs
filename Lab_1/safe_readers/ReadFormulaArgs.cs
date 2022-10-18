using Lab_1.validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.safe_readers
{
    static class ReadFormulaArgs
    {
        public static int Read(string message)
        {
            Console.Clear();
            Console.Write(message);

            string? inputLine = Console.ReadLine();

            if (!int.TryParse(inputLine, out int x))
            {
                Console.WriteLine($"{inputLine} is incorrect.");
                Console.ReadKey();
                return Read(message);
            }

            return x;
        }
        public static int Read(string message, IArgsValidator<int> validator)
        {
            Console.Clear();
            Console.Write(message);

            string? inputLine = Console.ReadLine();

            if (!int.TryParse(inputLine, out int x))
            {
                Console.WriteLine($"{inputLine} is incorrect.");
                Console.ReadKey();
                return Read(message, validator);
            }

            if (!validator.IsValid(x, out string? errorMessage))
            {
                Console.WriteLine(errorMessage);
                Console.ReadKey();
                return Read(message, validator);
            }

            return x;
        }
    }
}
