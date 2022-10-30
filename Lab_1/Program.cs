using Lab_1.menu_tasks;
using Lab_1.safe_readers;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new();
            menu.AddMenuOption(1, "Hello World!", () => Console.WriteLine("Hello World!"));
            menu.AddMenuOption(2, new CalcTask());
            menu.AddMenuOption(3, new RecursionDateTask());
            menu.AddMenuOption(4, new StringsTask());

            do
            {
                menu.PrintMenu();

                int menuOption = ReadInteger.Read("> ");

                menu.ChoiceMenuOption(menuOption);
            }
            while (menu.State);
        }
    }
}