using AdventOfCode.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode.Tasks.Year2022
{
    public class Day04_CampCleanup : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day04_CampCleanup(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var part2 = false;
            var data = _readListFromFile.ReadFile(parameters.First()).ToList();

            if (parameters.Count() == 2 && bool.TryParse(parameters.ElementAt(1), out bool isPart2))
                part2 = isPart2;

            int result = 0;

            var pairs = data
                .Select(x => x.Split(',').Select(x => x.Split('-').Select(y => int.Parse(y)).ToArray()).ToArray());

            if (part2)
            {
                result = pairs
                    .Where(x => IsPartialyOverlap(x[0], x[1])
                        || IsPartialyOverlap(x[1], x[0]))
                    .Count();
            }
            else
            {
                result = pairs
                    .Where(x => IsFullyOverlap(x[0], x[1])
                        || IsFullyOverlap(x[1], x[0]))
                .Count();
            }

            return Task.FromResult(result.ToString());
        }

        private bool IsPartialyOverlap(int[] firstPair, int[] secondPair)
        {
            return firstPair[0] <= secondPair[0]
                && firstPair[1] >= secondPair[0];
        }

        private bool IsFullyOverlap(int[] firstPair, int[] secondPair)
        {
            return firstPair[0] <= secondPair[0] 
                && firstPair[1] >= secondPair[1];
        }
    }
}
