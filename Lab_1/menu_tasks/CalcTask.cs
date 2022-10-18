using Lab_1.safe_readers;
using Lab_1.validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.menu_tasks
{
    class CalcTask : Task
    {
        public CalcTask() => Title = "Calc: (Y - sqrt(X)) / Z";
        public override void Execute()
        {
            int x = ReadFormulaArgs.Read("Input x: ", new XValidator());
            int y = ReadFormulaArgs.Read("Input y: ");
            int z = ReadFormulaArgs.Read("Input z: ", new ZValidator());
            Console.WriteLine($"({y} - sqrt({x})) / {z} = {Calc(x, y, z)}");
        }
        private static double Calc(int x, int y, int z) => Math.Round((y - Math.Sqrt(x)) / z, 3);
    }
}
