using Lab_1.safe_readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.menu_tasks
{
    class RecursionDateTask : Task
    {
        public RecursionDateTask() => Title = "Recursion date";

        public override void Execute()
        {
            (DateOnly, DateOnly) firstDatePair = ReadDate.Read("Input the first date pair.");
            (DateOnly, DateOnly) secondDatePair = ReadDate.Read("Input the second date pair.");

            int dateSegment = CalcDateSegment(firstDatePair, secondDatePair);

            if (dateSegment == -1)
            {
                Console.WriteLine("The Ackerman function cannot be computed for m > 3 in the allotted time.");
                return;
            }

            Console.WriteLine("Perform result the Ackermann Function: " + CalcAckermannFunction(dateSegment, 5));
        }
        private static int CalcDateSegment((DateOnly, DateOnly) firstDatePair, (DateOnly, DateOnly) secondDatePair)
        {
            if (firstDatePair.Item1.Year != secondDatePair.Item1.Year || firstDatePair.Item2.Year != secondDatePair.Item2.Year ||
                firstDatePair.Item1.Month != secondDatePair.Item1.Month || firstDatePair.Item2.Month != secondDatePair.Item2.Month) return 0;

            DateOnly firstDate, secondDate;

            if (firstDatePair.Item1 >= secondDatePair.Item1) firstDate = firstDatePair.Item1;
            else firstDate = secondDatePair.Item1;

            if (firstDatePair.Item2 <= secondDatePair.Item2) secondDate = firstDatePair.Item2;
            else secondDate = secondDatePair.Item2;

            int yearDifference = secondDate.Year - firstDate.Year;

            DateOnly dateDifference = secondDate.AddMonths(-(yearDifference * 12 + firstDate.Month));
            dateDifference = dateDifference.AddDays(-firstDate.Day);

            int m = dateDifference.Day + 1;

            if (m > 3) m = -1;

            return m;
        }
        private static int CalcAckermannFunction(int m, int n)
        {
            if (m == 0) return n + 1;

            if (m > 0 && n == 0) return CalcAckermannFunction(m - 1, 1);

            return CalcAckermannFunction(m - 1, CalcAckermannFunction(m, n - 1));
        }
    }
}
