using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.menu_items
{
    delegate void ExecuteHandler();

    abstract class MenuOption
    {
        public string Title { get; protected set; } = "Title";
        public abstract void Execite();
    }
}
