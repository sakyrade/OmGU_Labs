using Lab_1.menu_tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class RecursionDateArgsParser : ArgumentsParser<RecursionDateTask>
    {
        public override void Parser(RecursionDateTask recursionDateTask)
        {
            string[] args = recursionDateTask.Args;

            if (args.Length - 2 != 8) throw new ValidationException("Not enough arguments.");

            Dictionary<string, DateOnly> dictArgs = new()
            {
                { "-d1st", new() },
                { "-d1end", new() },
                { "-d2st", new() },
                { "-d2end", new() }
            };

            for (int i = 2; i < args.Length; i++)
            {
                if (i % 2 == 0 && dictArgs.ContainsKey(args[i])) continue;
                else if (DateOnly.TryParse(args[i], out DateOnly temp)) dictArgs[args[i - 1]] = temp;
                else throw new ValidationException($"{args[i]} is incorrect.");
            }

            recursionDateTask?.Init((dictArgs["-d1st"], dictArgs["-d1end"]), (dictArgs["-d2st"], dictArgs["-d2end"]));
        }
    }
}
