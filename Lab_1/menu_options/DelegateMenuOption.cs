using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.menu_items
{
    class DelegateMenuOption : MenuOption
    {
        private event ExecuteHandler OnExecute;
        public DelegateMenuOption(string title, ExecuteHandler handler)
        {
            Title = title;
            OnExecute += handler;
        }

        public override void Execite() => OnExecute?.Invoke();
    }
}
