using Lab_1.menu_tasks;
using Lab_1.safe_readers;
using Lab_1.validation;

namespace Lab_1
{
    class Program
    {
        private static void CalcStarting(menu_tasks.Task sender)
        {
            CalcTask? calcTask = sender as CalcTask;

            try
            {
                int x = ReadInteger.Read("Input x: ");
                XValidator.IsValid(x);
                int y = ReadInteger.Read("Input y: ");
                int z = ReadInteger.Read("Input z: ");
                ZValidator.IsValid(z);

                calcTask?.Init(x, y, z);
            }
            catch (ValidationException validErr)
            {
                Console.WriteLine(validErr.Message);
                Console.ReadLine();
                Console.Clear();
                CalcStarting(sender);
            }
        }
        private static void CalcStartingForTerminalMode(menu_tasks.Task sender)
        {
            CalcTask? calcTask = sender as CalcTask;

            try
            {
                CalcArgsParser argsParser = new CalcArgsParser();
                argsParser.Parser(calcTask);
            }
            catch (ValidationException validErr)
            {
                Console.WriteLine(validErr.Message);
            }
        }
        private static void RecursionDateCalcStarting(menu_tasks.Task sender)
        {
            (DateOnly, DateOnly) firstDatePair = DateReader.Read("Input the first date pair.");
            (DateOnly, DateOnly) secondDatePair = DateReader.Read("Input the second date pair.");

            RecursionDateTask? recDateTask = sender as RecursionDateTask;
            recDateTask?.Init(firstDatePair, secondDatePair);
        }
        private static void StringsStarting(menu_tasks.Task sender)
        {
            string firstString = safe_readers.StringReader.Read("Input first string: ");
            string secondString = safe_readers.StringReader.Read("Input second string: ");

            StringsTask? stringsTask = sender as StringsTask;

            stringsTask?.Init(firstString, secondString);
        }
        private static void StringsStartingForTerminalMode(menu_tasks.Task sender)
        {
            StringsTask? stringsTask = sender as StringsTask;

            try
            {
                StringsArgsParser argsParser = new StringsArgsParser();
                argsParser.Parser(stringsTask);
            }
            catch (ValidationException validErr)
            {
                Console.WriteLine(validErr.Message);
            }
        }
        private static void RecursionDateCalcStartingForTerminalMode(menu_tasks.Task sender)
        {
            RecursionDateTask? recDateTask = sender as RecursionDateTask;

            try
            {
                RecursionDateArgsParser argsParser = new RecursionDateArgsParser();
                argsParser.Parser(recDateTask);
            }
            catch (ValidationException validErr)
            {
                Console.WriteLine(validErr.Message);
            }
        }
        private static void RecursionDateCalcCompleted(menu_tasks.Task sender)
        {
            RecursionDateTask? recursionDateTask = sender as RecursionDateTask;

            if (recursionDateTask?.Result == -1)
            {
                Console.WriteLine("The Ackerman function cannot be computed for m > 3 in the allotted time.");
                return;
            }

            Console.WriteLine("Perform result the Ackermann Function: " + recursionDateTask?.Result);
        }
        private static void CalcCompleted(menu_tasks.Task sender)
        {
            CalcTask? calcTask = sender as CalcTask;

            Console.WriteLine($"({calcTask?.Y} - sqrt({calcTask?.X})) / {calcTask?.Z} = {calcTask?.Result}");
        }
        static void Main(string[] args)
        {
            int menuOption;
            Menu menu = new();
            menu.AddMenuOption(1, "Hello World!", () => Console.WriteLine("Hello World!"));

            if (args.Length != 0)
            {
                menu.AddMenuOption(2, new CalcTask(CalcStartingForTerminalMode, CalcCompleted, args));
                menu.AddMenuOption(3, new RecursionDateTask(RecursionDateCalcStartingForTerminalMode, RecursionDateCalcCompleted, args));
                menu.AddMenuOption(4, new StringsTask(Console.WriteLine, StringsStartingForTerminalMode, args));

                if (!args[0].Equals("-mi"))
                {
                    Console.WriteLine("Not enough arguments.");
                    return;
                }

                if (!int.TryParse(args[1], out menuOption))
                {
                    Console.WriteLine($"{args[1]} is incorrect.");
                    return;
                }

                menu.ChoiceMenuOption(menuOption);

                return;
            }

            menu.AddMenuOption(2, new CalcTask(CalcStarting, CalcCompleted));
            menu.AddMenuOption(3, new RecursionDateTask(RecursionDateCalcStarting, RecursionDateCalcCompleted));
            menu.AddMenuOption(4, new StringsTask(Console.WriteLine, StringsStarting));

            do
            {
                menu.PrintMenu();

                menuOption = ReadInteger.Read("> ");

                menu.ChoiceMenuOption(menuOption);
            }
            while (menu.State);
        }
    }
}