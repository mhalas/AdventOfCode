using AdventOfCode.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode.Tasks.Year2023
{
    public class Day02_CubeConundrum : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day02_CubeConundrum(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var part2 = false;
            var data = _readListFromFile.ReadFile(parameters.First()).ToList();

            if (parameters.Count() == 2 && bool.TryParse(parameters.ElementAt(1), out bool isPart2))
                part2 = isPart2;

            var games = data
                .Select(x => x.Split(": "))
                .Select(x => new
                {
                    GameNumber = int.Parse(x[0].Split(" ")[1]),
                    Sets = x[1]
                        .Split("; ")
                        .Select(x => x
                            .Split(", ")
                            .Select(x => x.Split(" "))
                            .Select(x => new
                            {
                                Color = x[1],
                                Count = int.Parse(x[0])
                            }))
                });

            if (!part2)
            {
                var part1Result = games
                    .Where(x => x.Sets.All(y => y.All(z =>
                        z.Color == "red" && z.Count <= 12
                        || z.Color == "green" && z.Count <= 13
                        || z.Color == "blue" && z.Count <= 14)))
                    .Sum(x => x.GameNumber);

                return Task.FromResult(part1Result.ToString());
            }

            var part2Result = games.
                Select(g => g.Sets
                    .SelectMany(set => set)
                    .GroupBy(cube => cube.Color, cube => cube.Count)
                    .Select(group => group.Max())
                    )
                .Select(x => x.Aggregate((x, y) => x * y))
                .Sum();
            
            return Task.FromResult(part2Result.ToString());
        }
    }
}