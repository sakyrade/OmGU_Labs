using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.menu_tasks
{
    public delegate void TaskCompletedHandler(Task sender);
    public delegate void TaskStartingHandler(Task sender);
    public abstract class Task
    {
        public string Title { get; protected set; } = "Title";
        public string[] Args { get; protected set; }
        public abstract void Execute();
    }
}
