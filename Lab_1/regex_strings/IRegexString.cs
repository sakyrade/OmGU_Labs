using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.regex_strings
{
    interface IRegexString
    {
        string RegexString { get; }
        string SuccessMessage { get; }
        string FailureMessage { get; }
    }
}
