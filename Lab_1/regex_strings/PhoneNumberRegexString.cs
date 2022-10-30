using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.regex_strings
{
    class PhoneNumberRegexString : RegexValidator
    {
        public PhoneNumberRegexString() : base(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$") { }
        public override string ToString() => "Phone Number";
    }
}
