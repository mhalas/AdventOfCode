using AdventOfCode.Shared.Contracts;
using Force.DeepCloner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tasks.Year2020
{
    public class Day11_SeatingSystem : IAdventTask
    {
        private readonly char SeatEmpty = 'L';
        private readonly char SeatOccupied = '#';
        private readonly char Floor = '.';


        private readonly IReadListFromFile _readListFromFile;

        public Day11_SeatingSystem(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            int maxOccupiedAdjacent = 4;
            bool part2 = false;
            var lastRound = _readListFromFile.ReadFile(parameters.First()).ToList();

            if (parameters.Count() >= 2 && int.TryParse(parameters.ElementAt(1), out int arg2))
                maxOccupiedAdjacent = arg2;
            if (parameters.Count() >= 3 && bool.TryParse(parameters.ElementAt(2), out bool arg3))
                part2 = arg3;


            var currentRound = lastRound.DeepClone();
            do
            {
                lastRound = currentRound.DeepClone();

                for (int y = 0; y < lastRound.Count; y++)
                {
                    for (int x = 0; x < lastRound[y].Length; x++)
                    {
                        if (lastRound[y][x] == Floor)
                            continue;

                        List<char> neighbours = new List<char>();
                        if (part2)
                            neighbours = GetAdvancedOccupiedNeighbours(lastRound, x, y);
                        else
                            neighbours = GetOccupiedNeighbours(lastRound, x, y);

                        StringBuilder currentRow = new StringBuilder(currentRound[y]);
                        if (lastRound[y][x] == SeatEmpty && !neighbours.Any(n => n == SeatOccupied))
                        {
                            currentRow[x] = SeatOccupied;
                            currentRound[y] = currentRow.ToString();
                        }
                        else if(lastRound[y][x] == SeatOccupied && neighbours.Count(n=>n == SeatOccupied) >= maxOccupiedAdjacent)
                        {
                            currentRow[x] = SeatEmpty;
                            currentRound[y] = currentRow.ToString();
                        }
                    }
                }
            }
            while (lastRound.Except(currentRound).Any());

            var count = currentRound.SelectMany(x => x).Count(x => x == SeatOccupied);

            return Task.FromResult(count.ToString());
        }

        private List<char> GetAdvancedOccupiedNeighbours(List<string> lastRound, int x, int y)
        {
            var result = new List<char>();

            if (y >= 0 && y != lastRound.Count - 1)
            {
                if (x >= 0 && x != lastRound[y].Length - 1)
                {
                    result.Add(GetElementByCross(lastRound, x, y, 1, 0));
                    result.Add(GetElementByCross(lastRound, x, y, 1, 1));
                }

                if (x <= lastRound[y].Length - 1 && x != 0)
                {
                    result.Add(GetElementByCross(lastRound, x, y, -1, 0));
                    result.Add(GetElementByCross(lastRound, x, y, -1, 1));
                }

                result.Add(GetElementByCross(lastRound, x, y, 0, 1));
            }

            if (y <= lastRound.Count - 1 && y != 0)
            {
                if (x >= 0 && x != lastRound[y].Length - 1)
                {
                    if (!(y >= 0 && y != lastRound.Count - 1))
                        result.Add(GetElementByCross(lastRound, x, y, 1, 0));

                    result.Add(GetElementByCross(lastRound, x, y, 1, -1));
                }

                if (x <= lastRound[y].Length - 1 && x != 0)
                {
                    if (!(y >= 0 && y != lastRound.Count - 1))
                        result.Add(GetElementByCross(lastRound, x, y, -1, 0));

                    result.Add(GetElementByCross(lastRound, x, y, -1, -1));
                }

                result.Add(GetElementByCross(lastRound, x, y, 0, -1));
            }

            return result;
        }

        private char GetElementByCross(List<string> lastRound, int startX, int startY, int moveX, int moveY)
        {
            var xMax = lastRound[startY].Length - 1;
            int x = startX + moveX;
            int y = startY + moveY;

            while (y >= 0 && y <= lastRound.Count - 1 && x >= 0 && x <= xMax)
            {
                if (lastRound[y][x] != Floor)
                    return lastRound[y][x];

                x += moveX;
                y += moveY;
            }

            return Floor;
        }

        private List<char> GetOccupiedNeighbours(List<string> lastRound, int x, int y)
        {
            var result = new List<char>();

            if(y >= 0 && y != lastRound.Count - 1)
            {
                if (x >= 0 && x != lastRound[y].Length - 1)
                {
                    result.Add(lastRound[y][x + 1]);
                    result.Add(lastRound[y + 1][x + 1]);
                }

                if(x <= lastRound[y].Length - 1 && x != 0)
                {
                    result.Add(lastRound[y][x - 1]);
                    result.Add(lastRound[y + 1][x - 1]);
                }

                result.Add(lastRound[y + 1][x]);
            }

            if(y <= lastRound.Count - 1 && y != 0)
            {
                if (x >= 0 && x != lastRound[y].Length - 1)
                {
                    if (!(y >= 0 && y != lastRound.Count - 1))
                        result.Add(lastRound[y][x + 1]);

                    result.Add(lastRound[y - 1][x + 1]);
                }

                if (x <= lastRound[y].Length - 1 && x != 0)
                {
                    if (!(y >= 0 && y != lastRound.Count - 1))
                        result.Add(lastRound[y][x - 1]);

                    result.Add(lastRound[y - 1][x - 1]);
                }

                result.Add(lastRound[y - 1][x]);
            }

            return result;
        }
    }
}
