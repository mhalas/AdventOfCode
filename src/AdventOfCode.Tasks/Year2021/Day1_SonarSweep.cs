using AdventOfCode.Shared.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Tasks.Year2021
{
    public class Day1_SonarSweep : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day1_SonarSweep(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> args)
        {
            var arguments = args.ToList();
            var path = arguments[0];
            var numbers = _readListFromFile.ReadFile(path).Select(x => int.Parse(x)).ToArray();

            var groupValuesCount = 1;

            if(arguments.Count != 1 && int.TryParse(arguments[1], out int groupValueCountArgument))
            {
                groupValuesCount = groupValueCountArgument;
            }
            var result = 0;

            for (int i = groupValuesCount; i < numbers.Length; i++)
            {
                var firstGroupSum = GetGroupValue(numbers, groupValuesCount, i, 0);
                var secondGroupSum = GetGroupValue(numbers, groupValuesCount, i, 1);

                if (firstGroupSum > secondGroupSum)
                    result++;
            }

            return Task.FromResult(result.ToString());
        }

        private static int GetGroupValue(int[] numbers, int groupValuesCount, int i, int startIndex)
        {
            var result = 0;

            for (int j = startIndex; j < startIndex + groupValuesCount; j++)
            {
                result += numbers[i - j];
            }

            return result;
        }
    }
}
