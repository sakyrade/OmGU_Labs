using Lab_1.menu_items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    static class Menu
    {
        private static Dictionary<int, MenuOption> idMenuOptionsPairs = new Dictionary<int, MenuOption>();
        public static void AddMenuOption(int id, string title, ExecuteHandler execute) => idMenuOptionsPairs.Add(id, new DelegateMenuOption(title, execute));
        public static void AddMenuOption(int id, MenuOption menuOption) => idMenuOptionsPairs.Add(id, menuOption);
        
        public static bool ChoiceMenuOption(int menuOption)
        {
            Console.Clear();

            if (menuOption == 0) return false;

            if (!idMenuOptionsPairs.ContainsKey(menuOption))
            {
                Console.WriteLine("Incorrect menu option. Try again.");
                Console.ReadKey();
                return true;
            }

            idMenuOptionsPairs[menuOption].Execite();

            Console.ReadKey();

            return true;
        }
        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("[0] Exit");
            foreach (int key in idMenuOptionsPairs.Keys) Console.WriteLine($"[{key}] {idMenuOptionsPairs[key].Title}");
            Console.Write("> ");
        }
    }
}
