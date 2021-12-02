using AdventOfCode.Shared.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Tasks.Year2021
{
    public class Day2_Dive : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day2_Dive(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> args)
        {
            var arguments = args.ToList();
            var path = arguments[0];
            var actions = _readListFromFile.ReadFile(path).Select(x => x.Split(' '));

            var result = 0;

            if(arguments.Count != 1 
                && bool.TryParse(arguments[1], out bool isAdvancedCalculations) 
                && isAdvancedCalculations)
            {
                result = GetAdvancedCalculations(actions);
            }
            else
            {
                result = GetSimpleCalculations(actions);
            }


            return Task.FromResult(result.ToString());
        }

        private int GetAdvancedCalculations(IEnumerable<string[]> actions)
        {
            var sumForward = 0;
            var aim = 0;
            var depth = 0;

            foreach (var action in actions)
            {
                var value = int.Parse(action[1]);

                if (action[0] == "forward")
                {
                    sumForward += value;
                    depth += value * aim;
                }
                else if (action[0] == "up")
                {
                    aim -= value;
                }
                else if (action[0] == "down")
                {
                    aim += value;
                }
            }

            var result = sumForward * depth;
            return result;
        }

        private int GetSimpleCalculations(IEnumerable<string[]> actions)
        {
            var sumForward = 0;
            var depth = 0;

            foreach (var action in actions)
            {
                var value = int.Parse(action[1]);

                if (action[0] == "forward")
                {
                    sumForward += value;
                }
                else if (action[0] == "up")
                {
                    depth -= value;
                }
                else if (action[0] == "down")
                {
                    depth += value;
                }
            }

            var result = sumForward * depth;
            return result;
        }
    }
}
