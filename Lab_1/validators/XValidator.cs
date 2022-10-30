﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.validation
{
    class XValidator : IValidator<int>
    {
        public void IsValid(int x)
        {
            if (x < 0)
                throw new ValidationException("x can't be less zero.");
        }
    }
}
