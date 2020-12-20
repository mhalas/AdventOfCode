using AdventOfCode.Shared.Contracts;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Tasks.Year2020
{
    public class Day10_AdapterArray: IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day10_AdapterArray(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var data = _readListFromFile.ReadFile(parameters.First());
            var adapters = data.Select(x => int.Parse(x)).OrderBy(x => x).AsEnumerable();

            if (parameters.Count() == 2 && bool.Parse(parameters.ElementAt(1)) == true)
            {
                var memo = new Dictionary<int, long>();
                return Task.FromResult(GetNumberOfDistinctWays(ref adapters, ref memo, new List<int> { 0 }).ToString());
            }

            return Task.FromResult(GetDifferencesMultiply(adapters));
        }

        private long GetNumberOfDistinctWays(ref IEnumerable<int> adapters, ref Dictionary<int, long> memo, IEnumerable<int> currentNumbers)
        {
            var result = (long)0;
            foreach (var n in currentNumbers)
            {
                if (memo.ContainsKey(n))
                {
                    result += memo[n];
                    continue;
                }

                var validAdapters = adapters.Where(x => x > n && x <= n + 3);
                if (!validAdapters.Any())
                {
                    result++;
                    continue;
                }

                var getWaysOfCurrentNumber = GetNumberOfDistinctWays(ref adapters, ref memo, validAdapters);
                memo.Add(n, getWaysOfCurrentNumber);
                result += getWaysOfCurrentNumber;
            }

            return result;
        }

        private string GetDifferencesMultiply(IEnumerable<int> adapters)
        {
            int[] differences = new int[3] { 0, 0, 0 };

            int currentAdapter = 0;

            foreach (var a in adapters)
            {
                if (a - currentAdapter >= 1 && a - currentAdapter <= 3)
                    differences[a - currentAdapter - 1]++;
                else
                    return $"Error? Differences: {string.Join(", ", differences)}.";

                currentAdapter = a;
            }

            differences[2]++;
            currentAdapter += 3;

            return (differences[0] * differences[2]).ToString();
        }
    }
}
