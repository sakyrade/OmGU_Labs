using Lab_1.menu_items;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.AddMenuOption(1, "Hello World!", HelloWorld.PrintHelloWorld);
            Menu.AddMenuOption(2, new CalcMenuOption());
            Menu.AddMenuOption(3, new RecursionDateMenuOption());

            int menuOption;

            do
            {
                Menu.PrintMenu();

                if (!int.TryParse(Console.ReadLine(), out menuOption))
                {
                    menuOption = -1;
                    continue;
                }
            }
            while (Menu.ChoiceMenuOption(menuOption));
        }
    }
}