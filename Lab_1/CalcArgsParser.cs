using Lab_1.menu_tasks;
using Lab_1.validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Lab_1.menu_tasks.Task;

namespace Lab_1
{
    internal class CalcArgsParser : ArgumentsParser<CalcTask>
    {
        public CalcArgsParser() { }
        public override void Parser(CalcTask calcTask)
        {
            string[] args = calcTask.Args;

            if (args.Length - 2 != 6) throw new ValidationException("Not enough arguments.");

            Dictionary<string, int> dictArgs = new()
            {
                { "-x", 0 },
                { "-y", 0 },
                { "-z", 0 }
            };

            for (int i = 2; i < args.Length; i++)
            {
                if (i % 2 == 0 && dictArgs.ContainsKey(args[i])) continue;
                else if (int.TryParse(args[i], out int temp)) dictArgs[args[i - 1]] = temp;
                else throw new ValidationException($"{args[i]} is incorrect.");
            }

            calcTask?.Init(dictArgs["-x"], dictArgs["-y"], dictArgs["-z"]);
        }
    }
}
