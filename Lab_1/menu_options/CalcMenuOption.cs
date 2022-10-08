using Lab_1.safe_readers;
using Lab_1.validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.menu_items
{
    class CalcMenuOption : MenuOption
    {
        public CalcMenuOption() => Title = "Calc: (Y - sqrt(X)) / Z";
        public override void Execite()
        {
            int x = ReadFormulaArgs.Read("Input x: ", new XValidator());
            int y = ReadFormulaArgs.ReadInt("Input y: ");
            int z = ReadFormulaArgs.Read("Input z: ", new ZValidator());
            Formula formula = new(x, y, z);
            Console.WriteLine($"({y} - sqrt({x})) / {z} = {formula.Calc()}");
        }
    }
}
