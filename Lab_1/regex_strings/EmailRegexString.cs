using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.regex_strings
{
    class EmailRegexString : IRegexString
    {
        public string RegexString { get; } = @"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+";
        public string SuccessMessage { get; } = " is email address.";
        public string FailureMessage { get; } = " is not email address.";
        public EmailRegexString () { }
    }
}
