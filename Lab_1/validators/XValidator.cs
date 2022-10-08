using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.validation
{
    class XValidator : IArgsValidator
    {
        public bool IsValid(int x, out string? errorMessage)
        {
            if (x < 0)
            {
                errorMessage = "x can't be less zero.";
                return false;
            }

            errorMessage = null;
            return true;
        }
    }
}
