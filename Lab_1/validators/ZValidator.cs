using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.validation
{
    class ZValidator : IArgsValidator<int>
    {
        public bool IsValid(int z, out string? errorMessage)
        {
            if (z == 0)
            {
                errorMessage = "z cannot be equal to zero.";
                return false;
            }

            errorMessage = null;
            return true;
        }
    }
}
