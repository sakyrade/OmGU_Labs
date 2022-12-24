using Lab_1.safe_readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.menu_tasks
{
    public class RecursionDateTask : Task
    {
        private event TaskCompletedHandler OnRecursionDateTaskCompleted;
        private event TaskStartingHandler OnRecursionDateTaskStarting;
        public (DateOnly, DateOnly) FirstDatePair { get; private set; }
        public (DateOnly, DateOnly) SecondDatePair { get; private set; }
        public int Result { get; private set; }
        public RecursionDateTask() { }
        public RecursionDateTask(TaskStartingHandler startHandler, TaskCompletedHandler completeHandler, string[] args = null)
        {
            Title = "Recursion date";
            OnRecursionDateTaskStarting += startHandler;
            OnRecursionDateTaskCompleted += completeHandler;
            Args = args;
        }
        public override void Execute()
        {
            OnRecursionDateTaskStarting?.Invoke(this);

            int dateSegment = CalcDateSegment(FirstDatePair, SecondDatePair);

            if (dateSegment != -1) Result = CalcAckermannFunction(dateSegment, 5);
            else Result = dateSegment;

            OnRecursionDateTaskCompleted?.Invoke(this);
        }
        public void Init((DateOnly, DateOnly) firstDatePair, (DateOnly, DateOnly) secondDatePair)
        {
            FirstDatePair = firstDatePair;
            SecondDatePair = secondDatePair;
        }
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
        public static int CalcAckermannFunction(int m, int n)
        {
            if (m == 0) return n + 1;

            if (m > 0 && n == 0) return CalcAckermannFunction(m - 1, 1);

            return CalcAckermannFunction(m - 1, CalcAckermannFunction(m, n - 1));
        }
    }
}
