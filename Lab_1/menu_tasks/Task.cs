using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.menu_tasks
{
    abstract class Task
    {
        public string Title { get; protected set; } = "Title";
        public abstract void Execute();
    }
}
