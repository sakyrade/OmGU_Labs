using Lab_1.menu_tasks;

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

                if (!int.TryParse(Console.ReadLine(), out int menuOption))
                {
                    menuOption = -1;
                    continue;
                }

                menu.ChoiceMenuOption(menuOption);
            }
            while (menu.State);
        }
    }
}