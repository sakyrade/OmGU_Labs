using Lab_1.menu_tasks;

namespace Lab_1
{
    class Menu
    {
        public bool State { get; private set; }
        private Dictionary<int, menu_tasks.Task> idMenuOptionsPairs;

        public Menu()
        {
            idMenuOptionsPairs = new Dictionary<int, menu_tasks.Task>();
            State = true;
        }
        
        public void AddMenuOption(int id, string title, ExecuteHandler execute) => idMenuOptionsPairs.Add(id, new DelegateTask(title, execute));
        public void AddMenuOption(int id, menu_tasks.Task menuOption) => idMenuOptionsPairs.Add(id, menuOption);
        public void ChoiceMenuOption(int menuOption)
        {
            Console.Clear();

            if (menuOption == 0)
            {
                State = false;
                return;
            }

            if (!idMenuOptionsPairs.ContainsKey(menuOption))
            {
                Console.WriteLine("Incorrect menu option. Try again.");
                Console.ReadKey();
                return;
            }

            idMenuOptionsPairs[menuOption].Execute();

            Console.ReadKey();
        }
        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("[0] Exit");
            foreach (int key in idMenuOptionsPairs.Keys) Console.WriteLine($"[{key}] {idMenuOptionsPairs[key].Title}");
        }
    }
}
