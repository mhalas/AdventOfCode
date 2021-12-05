using AdventOfCode.Shared.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AdventOfCode.Tasks.Year2021
{
    public class Day4_GiantSquid : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day4_GiantSquid(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var part2 = false;
            var data = _readListFromFile.ReadFile(parameters.First()).ToList();

            if (parameters.Count() == 2 && bool.TryParse(parameters.ElementAt(1), out bool isPart2))
                part2 = isPart2;

            var randomNumbers = data
                .First()
                .Split(',')
                .Select(x => int.Parse(x));

            data.RemoveRange(0, 2);

            var boards = GetBoards(data);

            var winningBoard = FindWinningBoard(randomNumbers, boards, part2);

            if(winningBoard.Item1 == null)
            {
                return Task.FromResult(string.Empty);
            }

            var sumUnmarkedNumbers = winningBoard.Item1.Sum(x => x.Where(y=> !winningBoard.Item2.Contains(y)).Sum());

            return Task.FromResult((sumUnmarkedNumbers * winningBoard.Item2.Last()).ToString());
        }

        private (int[][], IEnumerable<int>) FindWinningBoard(IEnumerable<int> randomNumbers, List<int[][]> boards, bool findLastWinningBoard)
        {
            List<int> boardsThatWins = new List<int>();
            IEnumerable<int> lastWinningBoardNumbers = null;

            for (int i = 4; i < randomNumbers.Count(); i++)
            {
                var currentNumbers = randomNumbers.Take(i + 1);

                foreach (var board in boards)
                {
                    int[] columnValuesSelected = new int[board[0].Length];
                    int[] rowsValuesSelected = new int[board.Length];

                    for (int column = 0; column < columnValuesSelected.Length; column++)
                    {
                        for (int row = 0; row < rowsValuesSelected.Length; row++)
                        {
                            if (currentNumbers.Contains(board[row][column]))
                            {
                                columnValuesSelected[column]++;
                                rowsValuesSelected[row]++;
                            }
                        }
                    }

                    if((columnValuesSelected.Any(x=> x == 5)
                        || rowsValuesSelected.Any(x=> x == 5))
                        && !boardsThatWins.Contains(boards.IndexOf(board)))
                    {
                        boardsThatWins.Add(boards.IndexOf(board));
                        lastWinningBoardNumbers = currentNumbers;
                    }

                    if (!findLastWinningBoard && boardsThatWins.Any())
                    {
                        return (board, currentNumbers);
                    }
                }
            }

            return (boards.ElementAt(boardsThatWins.Last()), lastWinningBoardNumbers);
        }

        private List<int[][]> GetBoards(List<string> data)
        {
            var boards = new List<int[][]>();
            var currentBoard = new List<int[]>();

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == "")
                {
                    boards.Add(currentBoard.ToArray());
                    currentBoard = new List<int[]>();

                    continue;
                }

                currentBoard.Add(data[i]
                    .Split(' ')
                    .Where(x => !string.IsNullOrEmpty(x))
                    .Select(x => int.Parse(x))
                    .ToArray());
            }

            boards.Add(currentBoard.ToArray());

            return boards;
        }
    }
}
