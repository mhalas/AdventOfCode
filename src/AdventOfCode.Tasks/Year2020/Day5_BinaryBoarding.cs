using AdventOfCode.Shared.Contracts;
using AdventOfCode.Shared.Dto;
using AdventOfCode.Shared.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Tasks.Year2020
{
    public class Day5_BinaryBoarding : IAdventTask
    {
        private IReadListFromFile _readListFromFile;

        public Day5_BinaryBoarding(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public string Execute(IEnumerable<string> parameter)
        {
            var data = _readListFromFile.ReadFile(parameter.First());

            var results = data
                .Select(x => GetBoardingInformations(x))
                .OrderBy(x => x.SeatId);
            var resultWithHighestSeatId = results.Last();

            var mySeatId = GetMySeatId(results);

            return JsonConvert.SerializeObject(new BinaryBoardingResult(resultWithHighestSeatId, mySeatId));
        }

        private int GetMySeatId(IOrderedEnumerable<BinaryBoardingDto> results)
        {
            var firstSeatId = 6;
            var lastSeatId = results.Last();

            for (int i = firstSeatId; i < lastSeatId.SeatId; i++)
            {
                if (!results.Any(x => x.SeatId == i))
                    return i;
            }

            return 0;
        }

        private BinaryBoardingDto GetBoardingInformations(string binaryValue)
        {
            var binaryRow = binaryValue
                .Substring(0, 7)
                .Replace('F', '0')
                .Replace('B', '1');

            var binaryColumn = binaryValue
                .Substring(7)
                .Replace('L', '0')
                .Replace('R', '1');

            var row = Convert.ToInt32(binaryRow, 2);
            var column = Convert.ToInt32(binaryColumn, 2);
            var seatId = row * 8 + column;

            return new BinaryBoardingDto(binaryValue, row, column, seatId);
        }
    }
}
