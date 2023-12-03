using AdventOfCode.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode.Tasks.Year2023
{
    public class Day01_Trebuchet : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        private readonly IDictionary<string, int> _intDict = new Dictionary<string, int>()
        {
            { "one", 1 }, 
            { "two", 2 }, 
            { "three", 3 }, 
            { "four", 4 }, 
            { "five", 5 },
            { "six", 6 }, 
            { "seven", 7 }, 
            { "eight", 8 }, 
            { "nine", 9 }, 
            { "1", 1 },
            { "2", 2 },
            { "3", 3 },
            { "4", 4 },
            { "5", 5 },
            { "6", 6 },
            { "7", 7 },
            { "8", 8 },
            { "9", 9 },
        };

        public Day01_Trebuchet(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var part2 = false;
            var data = _readListFromFile.ReadFile(parameters.First()).ToList();

            if (parameters.Count() == 2 && bool.TryParse(parameters.ElementAt(1), out bool isPart2))
                part2 = isPart2;

            if(part2)
            {
                return ResultOfPart2(data);
            }

            return ResultOfPart1(data);
        }

        private Task<string> ResultOfPart1(List<string> data)
        {
            var result = data
                .Select(x => x.Select(y => int.TryParse(y.ToString(), out int number) ? y : (char?)null))
                .Select(x => x.Where(y => y.HasValue))
                .Select(x => int.Parse($"{x.First()}{x.Last()}"))
                .Sum()
                .ToString();

            return Task.FromResult(result);
        }

        private Task<string> ResultOfPart2(List<string> data)
        {
            var sum = 0;

            foreach (var row in data)
            {
                var numbers = GetIndexNumberPairs(row);

                sum += (numbers.First().Value * 10 + numbers.Last().Value);
            }

            return Task.FromResult(sum.ToString());
        }

        private IDictionary<int, int> GetIndexNumberPairs(string row)
        {
            var result = new Dictionary<int, int>();

            foreach(var pair in _intDict)
            {
                var index = row.IndexOf(pair.Key);

                if(index >= 0)
                {
                    result.Add(index, pair.Value);
                }
            }

            return result
                .OrderBy(x=>x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
