using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    static class DateSegment
    {
        public static int CalcDateSegment((DateOnly, DateOnly) firstDatePair, (DateOnly, DateOnly) secondDatePair)
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
    }
}
