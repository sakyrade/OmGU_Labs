using Lab_1.validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.safe_readers
{
    static class ReadInteger
    {
        public static int Read(string message)
        {
            Console.Write(message);

            int oldTopPosition = Console.GetCursorPosition().Top;
            string? inputLine = Console.ReadLine();
            if (!int.TryParse(inputLine, out int x))
            {
                Console.WriteLine($"{inputLine} is incorrect.");
                Console.ReadKey();
                Console.SetCursorPosition(0, Console.CursorTop - 2);
                Console.WriteLine(new string(' ', Console.BufferWidth));
                Console.WriteLine(new string(' ', Console.BufferWidth));
                Console.SetCursorPosition(0, oldTopPosition);

                return Read(message);
            }

            return x;
        }
        public static int Read(string message, IValidator<int> validator)
        {
            int oldTopPosition = 0;

            try
            {
                Console.Write(message);

                oldTopPosition = Console.GetCursorPosition().Top;

                string? inputLine = Console.ReadLine();

                if (!int.TryParse(inputLine, out int x))
                    throw new ValidationException($"{inputLine} is incorrect.");

                validator.IsValid(x);

                return x;
            }
            catch (ValidationException validationEx)
            {
                Console.WriteLine(validationEx.Message);
                Console.ReadKey();
                Console.SetCursorPosition(0, Console.CursorTop - 2);
                Console.WriteLine(new string(' ', Console.BufferWidth));
                Console.WriteLine(new string(' ', Console.BufferWidth));
                Console.SetCursorPosition(0, oldTopPosition);

                return Read(message, validator);
            }
        }
    }
}
