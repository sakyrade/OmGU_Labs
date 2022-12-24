using Lab_1.menu_tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class StringsArgsParser : ArgumentsParser<StringsTask>
    {
        public override void Parser(StringsTask stringsTask)
        {
            string[] args = stringsTask.Args;

            if (args.Length - 2 != 4) throw new ValidationException("Not enough arguments.");

            Dictionary<string, string> dictArgs = new()
            {
                { "-s1", "" },
                { "-s2", "" },
            };

            for (int i = 2; i < args.Length; i++)
            {
                if (i % 2 == 0 && dictArgs.ContainsKey(args[i])) continue;
                else if (!string.IsNullOrEmpty(args[i]) && !string.IsNullOrWhiteSpace(args[i])) dictArgs[args[i - 1]] = args[i];
                else throw new ValidationException($"{args[i]} is incorrect.");
            }

            stringsTask?.Init(dictArgs["-s1"], dictArgs["-s2"]);
        }
    }
}
