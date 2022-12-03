using AdventOfCode.Shared.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Tasks.Year2020
{
    public class Day09_EncodingError : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day09_EncodingError(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var data = _readListFromFile.ReadFile(parameters.First());
            var preamble = int.Parse(parameters.ElementAt(1));
            var numbers = data.Select(x => double.Parse(x));

            var part2 = false;
            if (parameters.Count() == 3)
                part2 = bool.Parse(parameters.ElementAt(2));

            var numbersToCheck = numbers.Count() - preamble;
            var part1Value = GetInvalidValue(preamble, numbers, numbersToCheck);

            if (!part2)
                return Task.FromResult(part1Value.ToString());
            
            return  Task.FromResult(FindEncryptionWeakness(numbers, part1Value).ToString());
        }

        private double FindEncryptionWeakness(IEnumerable<double> numbers, double part1Value)
        {
            for (int i = 0; i < numbers.Count() - 1; i++)
            {
                var numbersToSum = new List<double>() { numbers.ElementAt(i) };
                foreach (var v in numbers.ToList().GetRange(i + 1, numbers.Count() - i - 1))
                {
                    numbersToSum.Add(v);

                    var sum = numbersToSum.Sum();
                    if (sum == part1Value)
                    {
                        return numbersToSum.Min() + numbersToSum.Max();
                    }
                    else if (sum > part1Value)
                        break;

                }
            }

            return 0;
        }

        private double GetInvalidValue(int preamble, IEnumerable<double> numbers, int numbersToCheck)
        {
            var part1Value = 0d;
            for (int i = preamble; i < numbersToCheck; i++)
            {
                var preambleNumbers = numbers.ToList().GetRange(i - preamble, preamble);

                var number = numbers.ElementAt(i);

                var result = preambleNumbers.Where(x => preambleNumbers.Any(y => x != y && x + y == number));

                if (!result.Any())
                {
                    part1Value = number;
                    break;
                }
            }

            return part1Value;
        }
    }
}
