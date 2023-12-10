using AdventOfCode.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AdventOfCode.Tasks.Year2023
{
    public class Day04_Scratchcards : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day04_Scratchcards(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var part2 = false;
            var data = _readListFromFile.ReadFile(parameters.First()).ToList();

            if (parameters.Count() == 2 && bool.TryParse(parameters.ElementAt(1), out bool isPart2))
                part2 = isPart2;

            var cards = data
                .Select(x=>x.Split(": ")[1].Split(" | "))
                .Select(x=> new
                {
                    WinningNumbers = x[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)),
                    NumbersIHave = x[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)),
                }).ToList();

            var points = cards
                    .Select(x => x.NumbersIHave.Where(y => x.WinningNumbers.Contains(y)).Count())
                    .ToList();

            var result = part2 ? 
                GetResultOfPart2(points) :
                GetResultOfPart1(points);

            return Task.FromResult(result.ToString());
        }

        double GetResultOfPart1(IEnumerable<int> points)
        {
            return points
                .Where(x => x > 0)
                .Select(x => Math.Pow(2, x - 1))
                .Sum();
        }

        double GetResultOfPart2(IEnumerable<int> points)
        {
            var dict = points
                .Select((points, index) => new { points, index })
                .ToDictionary(x => x.index, x => x.points);

            var result = new Dictionary<int, int>();

            for(int i = dict.Count - 1; i >= 0; i--)
            {
                var resultForScratchcard = 0;

                for(var j = i + 1; j < i + 1 + dict[i] && j < dict.Count; j++)
                {
                    resultForScratchcard += result[j] + 1;
                }

                result.Add(i, resultForScratchcard);
            }

            return result.Sum(x=>x.Value) + points.Count();
        }
    }
}
