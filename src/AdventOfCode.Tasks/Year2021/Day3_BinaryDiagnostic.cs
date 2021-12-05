using AdventOfCode.Shared.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode.Tasks.Year2021
{
    public class Day3_BinaryDiagnostic : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day3_BinaryDiagnostic(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var part2 = false;
            var data = _readListFromFile.ReadFile(parameters.First()).ToList();
            var bitsArray = data
                .Select(x => x.Select(y => int.Parse(y.ToString())).ToArray())
                .ToArray();

            if (parameters.Count() == 2 && bool.TryParse(parameters.ElementAt(1), out bool isPart2))
                part2 = isPart2;

            double result = part2 == false ? 
                Part1(bitsArray)
                : Part2(bitsArray);

            return Task.FromResult(result.ToString());
        }

        private double Part1(int[][] bitsArray)
        {
            int[] sumColumns = new int[bitsArray[0].Length];
            foreach (var bitWord in bitsArray)
            {
                for (int i = 0; i < bitWord.Length; i++)
                {
                    sumColumns[i] += bitWord[i] == 1 ? 1 : -1;
                }
            }

            bool[] bits = new bool[bitsArray[0].Length];

            for (int i = 0; i < bits.Length; i++)
            {
                bits[i] = sumColumns[i] > 0 ? true : false;
            }

            var bitArray = new BitArray(bits);
            var firstValue = ConvertBitToInt(bitArray);
            var invertedBitArray = (BitArray)bitArray.Clone();
            invertedBitArray.Not();
            var secondValue = ConvertBitToInt(invertedBitArray);

            return firstValue * secondValue;
        }

        private double Part2(int[][] bitsArray)
        {
            var firstValue = GetValue(false);
            var secondValue = GetValue(true);

            return firstValue * secondValue;

            double GetValue(bool isSearchingCO2)
            {
                var bitsList = bitsArray.ToList();

                for (int i = 0; i < bitsArray[0].Length; i++)
                {
                    var sum = 0;

                    for (int row = 0; row < bitsList.Count; row++)
                    {
                        sum += bitsList[row][i] == 1 ? 1 : -1;
                    }

                    bitsList = bitsList.Where(x => sum > 0
                        ? (isSearchingCO2? x[i] == 0: x[i] == 1) :
                            sum < 0
                            ? (isSearchingCO2 ? x[i] == 1 : x[i] == 0) :
                                sum == 0 && isSearchingCO2 ?
                                    x[i] == 0 : x[i] == 1)
                        .ToList();

                    if (bitsList.Count == 1)
                        break;
                }

                var winningRow = bitsList.First();
                bool[] bits = new bool[winningRow.Length];

                for (int i = 0; i < bits.Length; i++)
                {
                    bits[i] = winningRow[i] > 0 ? true : false;
                }


                var bitArray = new BitArray(bits);
                var value = ConvertBitToInt(bitArray);

                return value;
            }
        }

        private double ConvertBitToInt(BitArray bitArray)
        {
            double result = 0;
            for (int i = bitArray.Length - 1; i >= 0; i--)
            {
                result += bitArray[i] ? Math.Pow(2, bitArray.Length - 1 - i) : 0;
            }

            return result;
        }

        public string ToBitString(BitArray bits)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < bits.Count; i++)
            {
                char c = bits[i] ? '1' : '0';
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
