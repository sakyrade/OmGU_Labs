using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Formula
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }

        public Formula(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double Calc() => Math.Round((Y - Math.Sqrt(X)) / Z, 3);
    }
}
