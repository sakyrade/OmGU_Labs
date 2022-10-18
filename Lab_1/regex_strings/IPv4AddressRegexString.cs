using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.regex_strings
{
    class IPv4AddressRegexString : IRegexString
    {
        public string RegexString { get; } = @"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}";

        public string SuccessMessage { get; } = " is IPv4 address.";

        public string FailureMessage { get; } = " is not IPv4 address";

        public IPv4AddressRegexString() { }
    }
}
