using AdventOfCode.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

            if (part2)
            {
                return Task.FromResult(GetResultOfPart2(data).ToString());
            }

            return Task.FromResult(GetResultOfPart1(data).ToString());
        }

        private int GetResultOfPart1(List<List<char>> data)
        {
            var sum = 0;

            for (int row = 0; row < data.Count(); row++)
            {
                var number = "";
                int startIndex = 0;

                for (int col = 0; col < data[row].Count; col++)
                {
                    if (_numbers.Contains(data[row][col]))
                    {
                        if (number.Length == 0)
                        {
                            startIndex = col;
                        }

                        number += data[row][col];
                    }
                    else if (number.Length > 0)
                    {
                        if (IsPartNumber(GetNeighbourChars(data, row, startIndex, number.Length)))
                        {
                            sum += int.Parse(number);
                        }

                        number = string.Empty;
                        startIndex = 0;
                    }
                }

                if (number.Length > 0)
                {
                    if (IsPartNumber(GetNeighbourChars(data, row, startIndex, number.Length)))
                    {
                        sum += int.Parse(number);
                    }

                    number = string.Empty;
                    startIndex = 0;
                }
            }

            return sum;

            bool IsPartNumber(IDictionary<Vector2, char> neighbourChars)
            {
                return neighbourChars.Any(x => x.Value != '.' && !_numbers.Contains(x.Value));
            }
        }

        private int GetResultOfPart2(List<List<char>> data)
        {
            var result = 0;

            IDictionary<Vector2, int> gearRatioNumberDictionary = new Dictionary<Vector2, int>();

            for (int row = 0; row < data.Count(); row++)
            {
                var number = "";
                int startIndex = 0;

                IDictionary<Vector2, char> neighbourChars;

                for (int col = 0; col < data[row].Count; col++)
                {
                    if (_numbers.Contains(data[row][col]))
                    {
                        if (number.Length == 0)
                        {
                            startIndex = col;
                        }

                        number += data[row][col];
                    }
                    else if (number.Length > 0)
                    {
                        neighbourChars = GetNeighbourChars(data, row, startIndex, number.Length);

                        var gearRatios = TryGetGearRatio(neighbourChars);

                        foreach (var vector in gearRatios)
                        {
                            if (gearRatioNumberDictionary.ContainsKey(vector))
                            {
                                result += gearRatioNumberDictionary[vector] * int.Parse(number);
                            }
                            else
                            {
                                gearRatioNumberDictionary.Add(vector, int.Parse(number));
                            }
                        }

                        number = string.Empty;
                        startIndex = 0;
                    }
                }

                if (number.Length > 0)
                {
                    neighbourChars = GetNeighbourChars(data, row, startIndex, number.Length);

                    var gearRatios = TryGetGearRatio(neighbourChars);

                    foreach (var vector in gearRatios)
                    {
                        if (gearRatioNumberDictionary.ContainsKey(vector))
                        {
                            result += gearRatioNumberDictionary[vector] * int.Parse(number);
                        }
                        else
                        {
                            gearRatioNumberDictionary.Add(vector, int.Parse(number));
                        }
                    }

                    number = string.Empty;
                    startIndex = 0;
                }
            }

            return result;

            IEnumerable<Vector2> TryGetGearRatio(IDictionary<Vector2, char> neighbourChars)
            {
                return neighbourChars.Where(x => x.Value == '*').Select(x=>x.Key);
            }
        }

        private IDictionary<Vector2, char> GetNeighbourChars(List<List<char>> data, int rowIndex, int startIndex, int numberLength)
        {
            var endIndex = startIndex + numberLength - 1;

            Dictionary<Vector2, char> neighbourChars = new Dictionary<Vector2, char>();

            if(rowIndex > 0)
            {
                for (int i = startIndex; i < startIndex + numberLength; i++)
                {
                    neighbourChars.Add(new Vector2(rowIndex - 1, i), data[rowIndex - 1][i]);
                }
            }

            if(rowIndex < data.Count - 2) 
            {
                for (int i = startIndex; i < startIndex + numberLength; i++)
                {
                    neighbourChars.Add(new Vector2(rowIndex + 1, i), data[rowIndex + 1][i]);
                }
            }

            if(startIndex > 0)
            {
                if(rowIndex > 0)
                {
                    neighbourChars.Add(new Vector2(rowIndex - 1, startIndex - 1), data[rowIndex - 1][startIndex - 1]);
                }

                neighbourChars.Add(new Vector2(rowIndex, startIndex - 1), data[rowIndex][startIndex - 1]);

                if(rowIndex < data.Count - 2)
                {
                    neighbourChars.Add(new Vector2(rowIndex + 1, startIndex - 1), data[rowIndex + 1][startIndex - 1]);
                }
            }

            if(endIndex < data[rowIndex].Count - 1)
            {
                if(rowIndex > 0)
                {
                    neighbourChars.Add(new Vector2(rowIndex - 1, endIndex + 1), data[rowIndex - 1][endIndex + 1]);
                }

                neighbourChars.Add(new Vector2(rowIndex, endIndex + 1), data[rowIndex][endIndex + 1]);

                if (rowIndex < data.Count - 2)
                {
                    neighbourChars.Add(new Vector2(rowIndex + 1, endIndex + 1), data[rowIndex + 1][endIndex + 1]);
                }
            }

            return neighbourChars;
        }
    }
}
