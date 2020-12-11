using AdventOfCode.Shared.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Tasks.Year2020
{
    public class Day10_AdapterArray: IAdventTask
    {
        private readonly int MaxTasks = 4;
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
                var memo = new Dictionary<int, IEnumerable<int>>();
                return Task.FromResult(GetNumberOfDistinctWays(ref adapters, ref memo, new List<int>() { 0 }).ToString());
            }

            return Task.FromResult(GetDifferencesMultiply(adapters));
        }

        private int GetNumberOfDistinctWays(ref IEnumerable<int> adapters, ref Dictionary<int, IEnumerable<int>> memo, IEnumerable<int> currentNumbers)
        {
            var result = 0;
            foreach (var n in currentNumbers)
            {
                if (memo.ContainsKey(n))
                {
                    result += GetNumberOfDistinctWays(ref adapters, ref memo, memo[n]);
                    continue;
                }

                var validAdapters = adapters.Where(x => x > n && x <= n + 3);
                if (!validAdapters.Any())
                {
                    result++;
                    break;
                }

                if (validAdapters.Count() > 1)
                {
                    memo.Add(n, validAdapters);
                    break;
                }

                validAdapters = adapters.Where(x => x > n && x <= n + 3);
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
