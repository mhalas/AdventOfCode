using AdventOfCode.Shared.Contracts;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode.Tasks.Year2021
{
    public class Day05_HydrothermalVenture : IAdventTask
    {
        private ILogger _logger = LogManager.GetCurrentClassLogger();

        private readonly IReadListFromFile _readListFromFile;

        public Day05_HydrothermalVenture(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var part2 = false;
            var data = _readListFromFile.ReadFile(parameters.First()).ToList();

            if (parameters.Count() == 2 && bool.TryParse(parameters.ElementAt(1), out bool isPart2))
                part2 = isPart2;

            var coords = data
                .Select(x => x.Split(new string[] { " -> " }, StringSplitOptions.None))
                .Select(x=> x.Select(y=> y.Split(',').Select(z=> int.Parse(z)).ToArray()).ToArray());

            if(part2 == false)
            {
                coords = coords.Where(x => x[0][0] == x[1][0] || x[0][1] == x[1][1]);
            }
            var coordsPositions = coords
                .SelectMany(x => GenerateVentPath(x))
                .GroupBy(x=>x)
                .ToDictionary(x=>x.Key, x=>x.Count());

            var result = coordsPositions
                .Where(x=> x.Value > 1)
                .Count();
            
            return Task.FromResult(result.ToString());
        }

        private IEnumerable<string> GenerateVentPath(int[][] coords)
        {
            var result = new List<string>();

            var startCoords = coords[0];
            var endCoords = coords[1];

            do
            {
                result.Add(string.Join(",", startCoords));

                if (startCoords[0] > endCoords[0])
                {
                    startCoords[0]--;
                }
                else if(startCoords[0] < endCoords[0])
                {
                    startCoords[0]++;
                }

                if(startCoords[1] > endCoords[1])
                {
                    startCoords[1]--;
                }
                else if(startCoords[1] < endCoords[1])
                {
                    startCoords[1]++;
                }
            }
            while (startCoords[0] != endCoords[0] || startCoords[1] != endCoords[1]);

            result.Add(string.Join(",", startCoords));

            return result;
        }
    }
}
