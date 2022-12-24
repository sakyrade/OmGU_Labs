using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.regex_strings
{
    public class EmailRegexString : RegexValidator
    {
        public EmailRegexString() : base(@"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+") { }
        public override string ToString() => "Email Address";
    }
}
