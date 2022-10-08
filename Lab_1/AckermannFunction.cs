using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    static class AckermannFunction
    {
        public static int CalcAckermannFunction(int m, int n)
        {
            if (m == 0) return n + 1;

            if (m > 0 && n == 0) return CalcAckermannFunction(m - 1, 1);

            return CalcAckermannFunction(m - 1, CalcAckermannFunction(m, n - 1));
        }
    }
}
