using AdventOfCode.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Tasks.Year2020
{
    public class Day13_ShuttleSearch : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day13_ShuttleSearch(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var part2 = false;
            var data = _readListFromFile.ReadFile(parameters.First()).ToList();

            if(parameters.Count() == 2 && bool.TryParse(parameters.ElementAt(1), out bool isPart2))
                part2 = isPart2;

            if (part2)
                return Task.FromResult(GetContestResult(data).ToString());
            else
                return Task.FromResult(GetEarliestBusResult(data).ToString());
        }

        private int GetEarliestBusResult(IEnumerable<string> data)
        {
            var timestamp = int.Parse(data.ElementAt(0));
            var buses = data.ElementAt(1).Replace("x,", "").Split(new string[] { "," }, StringSplitOptions.None).Select(x => int.Parse(x));

            var bus = buses.Select(x => new { Number = x, ArriveAt = (timestamp + x - (timestamp % x)) }).OrderBy(x => x.ArriveAt).First();

            return (bus.ArriveAt - timestamp) * bus.Number;
        }

        private double GetContestResult(IEnumerable<string> data)
        {
            var buses = data
                .ElementAt(1)
                .Split(new string[] { "," }, StringSplitOptions.None)
                .Select(x => int.TryParse(x, out int value)? (int?)value: null)
                .ToList();
            return 0;
        }
    }
}
