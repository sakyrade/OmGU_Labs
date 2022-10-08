using Lab_1.safe_readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.menu_items
{
    class RecursionDateMenuOption : MenuOption
    {
        public RecursionDateMenuOption() => Title = "Recursion date";

        public override void Execite()
        {
            (DateOnly, DateOnly) firstDatePair = ReadDate.ReadDatePair("Input the first date pair.");
            (DateOnly, DateOnly) secondDatePair = ReadDate.ReadDatePair("Input the second date pair.");

            int dateSegment = DateSegment.CalcDateSegment(firstDatePair, secondDatePair);

            if (dateSegment == -1)
            {
                Console.WriteLine("The Ackerman function cannot be computed for m > 3 in the allotted time.");
                return;
            }

            Console.WriteLine("Perform result the Ackermann Function: " + AckermannFunction.CalcAckermannFunction(dateSegment, 5));
        }
    }
}
