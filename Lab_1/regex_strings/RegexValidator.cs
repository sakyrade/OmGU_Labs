using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_1.regex_strings
{
    abstract class RegexValidator
    {
        private string regexString;

        public RegexValidator(string regexString) => this.regexString = regexString;

        public bool IsValid(string str) => Regex.IsMatch(str, regexString);
    }
}
