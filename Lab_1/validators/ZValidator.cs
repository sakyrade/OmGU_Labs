using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.validation
{
    static class ZValidator
    {
        public static void IsValid(int z)
        {
            if (z == 0)
                throw new ValidationException("z can't be equal to zero.");
        }
    }
}
