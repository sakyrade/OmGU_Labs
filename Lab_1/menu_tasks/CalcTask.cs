using Lab_1.safe_readers;
using Lab_1.validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.menu_tasks
{
    public class CalcTask : Task
    {
        public event TaskCompletedHandler? OnCalcTaskCompleted;
        public event TaskStartingHandler? OnCalcTaskStarting;
        public double Result { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public CalcTask() { }
        public CalcTask(TaskStartingHandler? startHandler,
                        TaskCompletedHandler? completeHandler, string[] args = null)
        {
            Title = "Calc: (Y - sqrt(X)) / Z";
            OnCalcTaskStarting += startHandler;
            OnCalcTaskCompleted += completeHandler;
            Args = args;
        }
        public void Init(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public override void Execute()
        {
            OnCalcTaskStarting?.Invoke(this);

            Result = Calc(X, Y, Z);

            OnCalcTaskCompleted?.Invoke(this);
        }
        public static double Calc(int x, int y, int z)
        {
            XValidator.IsValid(x);
            ZValidator.IsValid(z);

            return Math.Round((y - Math.Sqrt(x)) / z, 3);
        }
    }
}
