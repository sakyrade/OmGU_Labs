using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.validation
{
    class ZValidator : IValidator<int>
    {
        public void IsValid(int z)
        {
            if (z == 0)
                throw new ValidationException("z cannot be equal to zero.");
        }
    }
}
