using AdventOfCode.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AdventOfCode.Tasks.Year2023
{
    public class Day03_GearRatios : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        private readonly IEnumerable<char> _numbers = new List<char>()
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        public Day03_GearRatios(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var part2 = false;
            var data = _readListFromFile
                .ReadFile(parameters.First())
                .Select(x => x.Select(y => y).ToList()).ToList();

            if (parameters.Count() == 2 && bool.TryParse(parameters.ElementAt(1), out bool isPart2))
                part2 = isPart2;

            var sum = 0;

            for (int row = 0; row < data.Count(); row++)
            {
                var number = "";
                int startIndex = 0;

                for (int col = 0; col < data[row].Count; col++)
                {
                    if (_numbers.Contains(data[row][col]))
                    {
                        if(number.Length == 0)
                        {
                            startIndex = col;
                        }

                        number += data[row][col];
                    }
                    else if(number.Length > 0)
                    {
                        if(IsPartNumber(data, row, startIndex, number.Length))
                        {
                            sum += int.Parse(number);
                        }

                        number = string.Empty;
                        startIndex = 0;
                    }
                }
            }

            return Task.FromResult(sum.ToString());
        }

        private bool IsPartNumber(List<List<char>> data, int rowIndex, int startIndex, int numberLength)
        {
            var endIndex = startIndex + numberLength - 1;

            List<char> charsToCheck = new List<char>();

            if(rowIndex > 0)
            {
                charsToCheck.AddRange(data[rowIndex - 1].GetRange(startIndex, numberLength));
            }

            if(rowIndex < data.Count - 2) 
            {
                charsToCheck.AddRange(data[rowIndex + 1].GetRange(startIndex, numberLength));
            }

            if(startIndex > 0)
            {
                if(rowIndex > 0)
                {
                    charsToCheck.Add(data[rowIndex - 1][startIndex - 1]);
                }

                charsToCheck.Add(data[rowIndex][startIndex - 1]);

                if(rowIndex < data.Count - 2)
                {
                    charsToCheck.Add(data[rowIndex + 1][startIndex - 1]);
                }
            }

            if(endIndex < data[rowIndex].Count - 1)
            {
                if(rowIndex > 0)
                {
                    charsToCheck.Add(data[rowIndex - 1][endIndex + 1]);
                }

                charsToCheck.Add(data[rowIndex][endIndex + 1]);

                if (rowIndex < data.Count - 2)
                {
                    charsToCheck.Add(data[rowIndex + 1][endIndex + 1]);
                }
            }

            return charsToCheck.Any(x => x != '.' && !_numbers.Contains(x));
        }
    }
}
