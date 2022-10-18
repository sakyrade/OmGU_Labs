using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.validation
{
    interface IArgsValidator<T>
    {
        bool IsValid(T arg, out string? errorMessage);
    }
}
