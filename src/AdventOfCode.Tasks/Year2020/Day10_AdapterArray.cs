using AdventOfCode.Shared.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Tasks.Year2020
{
    public class Day10_AdapterArray: IAdventTask
    {
        private readonly int MaxTasks = 4;
        private IReadListFromFile _readListFromFile;

        public Day10_AdapterArray(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public async Task<string> Execute(IEnumerable<string> parameters)
        {
            var data = _readListFromFile.ReadFile(parameters.First());
            var adapters = data.Select(x => int.Parse(x)).OrderBy(x => x);

            return GetDifferencesMultiply(adapters);
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
