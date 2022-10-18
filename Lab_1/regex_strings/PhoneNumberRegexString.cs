using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.regex_strings
{
    class PhoneNumberRegexString : IRegexString
    {
        public string RegexString { get; } = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";

        public string SuccessMessage { get; } = " is phone number.";

        public string FailureMessage { get; } = " is not phone number.";
        public PhoneNumberRegexString() { }
    }
}
