using AdventOfCode.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AdventOfCode.Tasks.Year2022
{
    public class Day05_SupplyStacks : IAdventTask
    {
        private const int MoveCountIndex = 0;
        private const int FromIndex = 1;
        private const int ToIndex = 2;

        private readonly IReadListFromFile _readListFromFile;

        public Day05_SupplyStacks(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var part2 = false;
            var data = _readListFromFile.ReadFile(parameters.First()).ToList();

            if (parameters.Count() == 2 && bool.TryParse(parameters.ElementAt(1), out bool isPart2))
                part2 = isPart2;

            var emptySpaceIndex = data.IndexOf(string.Empty);

            var stacks = GetStacks(data, emptySpaceIndex);
            var actions = GetActions(data, emptySpaceIndex);

            foreach (var action in actions)
            {
                if (part2)
                {
                    MoveCratesThroughStack(stacks, action);
                }
                else
                {
                    MoveCratesThroughQueue(stacks, action);
                }
            }

            string result = string.Empty;
            stacks.ForEach(stack =>
            {
                char crate;
                if (stack.TryPeek(out crate))
                {
                    result += crate;
                }
            });

            return Task.FromResult(result);
        }

        private static void MoveCratesThroughQueue(List<Stack<char>> stacks, int[] action)
        {
            var popedCrates = new Queue<char>();

            for (int i = 0; i < action[MoveCountIndex]; i++)
            {
                char crate;

                if (stacks[action[FromIndex] - 1].TryPop(out crate))
                {
                    popedCrates.Enqueue(crate);
                }
            }

            foreach (var crate in popedCrates)
            {
                stacks[action[ToIndex] - 1].Push(crate);
            }
        }

        private static void MoveCratesThroughStack(List<Stack<char>> stacks, int[] action)
        {
            var popedCrates = new Stack<char>();

            for (int i = 0; i < action[MoveCountIndex]; i++)
            {
                char crate;

                if (stacks[action[FromIndex] - 1].TryPop(out crate))
                {
                    popedCrates.Push(crate);
                }
            }

            foreach (var crate in popedCrates)
            {
                stacks[action[ToIndex] - 1].Push(crate);
            }
        }

        private List<int[]> GetActions(List<string> data, int emptySpaceIndex)
        {
            return data.GetRange(emptySpaceIndex + 1, data.Count() - emptySpaceIndex - 1)
                .Select(x => x
                    .Replace("move ", "")
                    .Split(" from ")
                    .SelectMany(y => y.Split(" to "))
                    .Select(y => int.Parse(y.ToString()))
                    .ToArray())
                .ToList();
        }

        private static List<Stack<char>> GetStacks(List<string> data, int emptySpaceIndex)
        {
            List<Stack<char>> stackList = new List<Stack<char>>();

            var mapRange = data
                .GetRange(0, emptySpaceIndex);

            mapRange.RemoveAt(mapRange.Count - 1);

            var map = mapRange
                .Chunk(4)
                .SelectMany(x => x
                    .Select(y => y
                        .Replace("    ", " ")
                        .Replace("[", "")
                        .Replace("] ", "")
                        .Replace("]", "")))
                .Reverse()
                .ToList();

            for (int i = 0; i < map.Count(); i++)
            {
                var row = map[i];

                for (int j = 0; j < row.Length; j++)
                {
                    if (stackList.Count < j + 1)
                    {
                        stackList.Add(new Stack<char>());
                    }

                    if (string.IsNullOrWhiteSpace(row[j].ToString()))
                    {
                        continue;
                    }

                    stackList[j].Push(row[j]);
                }
            }

            return stackList;
        }
    }
}
