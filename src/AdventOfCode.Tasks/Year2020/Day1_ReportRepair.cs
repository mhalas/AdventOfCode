using AdventOfCode.Shared.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Tasks.Year2020
{
    public class Day1_ReportRepair : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        private readonly int _sumValue = 2020;

        public Day1_ReportRepair(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public string Execute(IEnumerable<string> args)
        {
            var arguments = args.ToList();
            int countToSum = 2;

            var path = arguments[0];
            var numbers = _readListFromFile.ReadFile(path).Select(x => int.Parse(x));

            if(arguments.Count() >= 2)
                countToSum = int.TryParse(arguments[1], out int parameter)? parameter: countToSum;

            var result = numbers.Where(n => GetAnotherNumber(numbers, n, 2, countToSum)).ToList();
            return result.Aggregate((a, x) => a * x).ToString();
        }

        private bool GetAnotherNumber(IEnumerable<int> numbers, int currentSum, int counter, int countToSum)
        {
            if(countToSum <= counter)
                return numbers.Any(second => currentSum + second == _sumValue);

            return numbers.Any(second => GetAnotherNumber(numbers, currentSum + second, ++counter, countToSum));
        }
    }
}