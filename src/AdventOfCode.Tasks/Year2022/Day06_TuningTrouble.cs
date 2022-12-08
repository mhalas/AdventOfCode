using AdventOfCode.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode.Tasks.Year2022
{
    public class Day06_TuningTrouble : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day06_TuningTrouble(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var distinctCharactersCount = 4;
            var data = _readListFromFile.ReadFile(parameters.First()).ToList();

            if (parameters.Count() == 2 && int.TryParse(parameters.ElementAt(1), out int arg1))
            {
                distinctCharactersCount = arg1;
            }

            var result = 0;

            var dataStream = data.First();

            for (int i = 0; i < dataStream.Length - distinctCharactersCount; i++)
            {
                var packet = dataStream.Substring(i, distinctCharactersCount);

                if (packet.All(x=> packet.Count(y=> y == x) == 1))
                {
                    result = i + distinctCharactersCount;
                    break;
                }
            }

            return Task.FromResult(result.ToString());
        }
    }
}
