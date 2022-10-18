using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.menu_tasks
{
    delegate void ExecuteHandler();
    class DelegateTask : Task
    {
        private event ExecuteHandler OnExecute;
        public DelegateTask(string title, ExecuteHandler handler)
        {
            Title = title;
            OnExecute += handler;
        }

        public override void Execute() => OnExecute?.Invoke();
    }
}
