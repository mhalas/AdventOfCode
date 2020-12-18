using AdventOfCode.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode.Tasks.Year2020
{
    public class Day14_DockingData : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day14_DockingData(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var part2 = false;
            var data = _readListFromFile.ReadFile(parameters.First()).ToList().Select(x=> x.Split( new string[] { " = " }, StringSplitOptions.None)).ToList();

            if (parameters.Count() == 2 && bool.TryParse(parameters.ElementAt(1), out bool isPart2))
                part2 = isPart2;

            var memoryResult = new Dictionary<int, ulong>();
            var currentMaskIndex = 0;
            var nextMaskIndex = data.FindIndex(1, x => x[0] == "mask");

            for (currentMaskIndex = 0; nextMaskIndex != -1 ; nextMaskIndex = data.FindIndex(currentMaskIndex + 1, x => x[0] == "mask"))
            {
                EditMemory(data, memoryResult, currentMaskIndex, nextMaskIndex);

                currentMaskIndex = nextMaskIndex;
            }

            EditMemory(data, memoryResult, currentMaskIndex, data.Count);

            var sum = memoryResult.Values.Select(x => x).Aggregate((x, y)=> x + y);
            return Task.FromResult(sum.ToString());
        }

        private void EditMemory(List<string[]> data, Dictionary<int, ulong> memoryResult, int currentMaskIndex, int nextMaskIndex)
        {
            var mask = data[currentMaskIndex][1].Reverse();
            var memoryChanges = data.GetRange(currentMaskIndex + 1, nextMaskIndex - 1 - currentMaskIndex);

            foreach (var changeAddress in memoryChanges)
            {
                var memoryAddressToChange = int.Parse(changeAddress[0].Substring(4, changeAddress[0].Length - 5));

                if (!memoryResult.ContainsKey(memoryAddressToChange))
                    memoryResult.Add(memoryAddressToChange, 0);

                memoryResult[memoryAddressToChange] = ulong.Parse(changeAddress[1]);

                for (int maskBitIndex = 0; maskBitIndex < mask.Count(); maskBitIndex++)
                {
                    var bitValue = mask.ElementAt(maskBitIndex);
                    if (bitValue == 'X')
                        continue;

                    memoryResult[memoryAddressToChange] = (memoryResult[memoryAddressToChange] & ~((ulong)1 << maskBitIndex) | ulong.Parse($"{bitValue}") << maskBitIndex);
                }
            }
        }
    }
}
