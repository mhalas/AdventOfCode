using AdventOfCode.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode.Tasks.Year2022
{
    public class Day03_RucksackReorganization : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        private const int AsciiCodeUppercaseStart = 65;
        private const int AsciiCodeLowercaseStart = 97;

        public Day03_RucksackReorganization(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var chunkSize = 1;
            var data = _readListFromFile.ReadFile(parameters.First()).ToList();

            if (parameters.Count() == 2 && int.TryParse(parameters.ElementAt(1), out int size))
                chunkSize = size;

            IEnumerable<IEnumerable<string>> xx = null;

            if(chunkSize == 1)
            {
                xx = data
                    .Select(x => x.Chunk((int)x.Length / 2).Select(x => string.Join("", x)));
            }
            else
            {
                xx = data
                    .Chunk(chunkSize)
                    .Select(x => x.AsEnumerable());
            }

            var result = xx
                .SelectMany(x => 
                    x.Aggregate((string string1, string string2) => 
                        { 
                            return string.Join("", string1.Intersect(string2)); 
                        }).ToArray())
                .Select(x => (int)x >= AsciiCodeLowercaseStart ? 
                    ((int)x) - AsciiCodeLowercaseStart + 1 : ((int)x) - AsciiCodeUppercaseStart + 27)
                .Sum();

            return Task.FromResult(result.ToString());
        }
    }
}
