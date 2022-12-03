using AdventOfCode.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Tasks.Year2020
{
    public class Day03_TobogganTrajectory: IAdventTask
    {
        private readonly int DEFAULT_MOVE_RIGHT_COUNT = 3;
        private readonly int DEFAULT_MOVE_DOWN_COUNT = 1;
        private readonly char TREE_CHARACTER = '#';

        private readonly IReadListFromFile _readListFromFile;

        public Day03_TobogganTrajectory(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameter)
        {
            var data = _readListFromFile.ReadFile(parameter.First());
            var map = data.ToList();

            List<KeyValuePair<int, int>> slopes = new List<KeyValuePair<int, int>>();

            if (parameter.Count() == 1)
                slopes.Add(new KeyValuePair<int, int>(DEFAULT_MOVE_RIGHT_COUNT, DEFAULT_MOVE_DOWN_COUNT));
            else
            {
                var otherParameters = parameter.ToList();
                otherParameters.RemoveAt(0);
                otherParameters.Select(x => x.Split(',')).ToList().ForEach((x) => slopes.Add(new KeyValuePair<int, int>(int.Parse(x[0]), int.Parse(x[1]))));
            }

            return Task.FromResult(slopes
                .Select(x => GetTreesCount(map, x.Key, x.Value))
                .Aggregate((x, y) => x * y)
                .ToString());
        }

        private double GetTreesCount(List<string> map, int moveRightCount, int moveDownCount)
        {
            int result = 0;

            int xPosition = 0;
            for (int y = moveDownCount; y < map.Count; y += moveDownCount)
            {
                xPosition += moveRightCount;
                if (map[y].Length <= xPosition)
                {
                    xPosition = xPosition - map[y].Length;
                }

                if (map[y][xPosition] == TREE_CHARACTER)
                    result++;
            }

            return (double)result;
        }
    }
}
