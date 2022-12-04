using AdventOfCode.Shared.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AdventOfCode.Tasks.Year2022
{
    public class Day02_RockPaperScissors : IAdventTask
    {
        private const int OpponentIndex = 0;
        private const int PlayerIndex = 2;

        private const char OpponentRock = 'A';
        private const char OpponentPaper = 'B';
        private const char OpponentScissors = 'C';

        private const char ScoreLose = 'X';
        private const char ScoreDraw = 'Y';
        private const char ScoreWin = 'Z';

        private const char PlayerRock = 'X';
        private const char PlayerPaper = 'Y';
        private const char PlayerScissors = 'Z';

        private const char Rock = 'R';
        private const char Paper = 'P';
        private const char Scissors = 'S';

        private const int LoseScore = 0;
        private const int DrawScore = 3;
        private const int WinScore = 6;

        private readonly IReadListFromFile _readListFromFile;

        private readonly IDictionary<char, char> _shapeDictionary = new Dictionary<char, char>()
        {
            { OpponentRock, Rock },
            { OpponentPaper, Paper },
            { OpponentScissors, Scissors },

            { PlayerRock, Rock },
            { PlayerPaper, Paper },
            { PlayerScissors, Scissors },
        };

        private readonly IDictionary<char, char> _winRules = new Dictionary<char, char>()
        {
            { Rock, Scissors },
            { Paper, Rock },
            { Scissors, Paper }
        };

        public Day02_RockPaperScissors(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var part2 = false;
            var data = _readListFromFile.ReadFile(parameters.First()).ToList();

            if (parameters.Count() == 2 && bool.TryParse(parameters.ElementAt(1), out bool isPart2))
                part2 = isPart2;

            IEnumerable<int> playerRoundsScore = null;

            if (part2)
            {
                playerRoundsScore = data
                .Select(x =>
                    CheckRoundScore(GetShapeByRoundScore(x[PlayerIndex], _shapeDictionary[x[OpponentIndex]]), 
                        _shapeDictionary[x[OpponentIndex]]) +
                    GetPlayerShapeScore(GetShapeByRoundScore(x[PlayerIndex], _shapeDictionary[x[OpponentIndex]])));
            }
            else
            {
                playerRoundsScore = data
                .Select(x => 
                    CheckRoundScore(_shapeDictionary[x[PlayerIndex]], _shapeDictionary[x[OpponentIndex]]) + 
                    GetPlayerShapeScore(_shapeDictionary[x[PlayerIndex]]));
            }
            
            
            return Task.FromResult(playerRoundsScore.Sum().ToString());
        }

        private char GetShapeByRoundScore(char score, char opponentShape)
        {
            switch(score)
            {
                case ScoreWin: return _winRules.Single(x => x.Value == opponentShape).Key;
                case ScoreDraw: return opponentShape;

                default: return _winRules[opponentShape];
            }
        }

        private int CheckRoundScore(char playerShape, char opponentShape)
        {
            if(char.Equals(playerShape, opponentShape))
            {
                return DrawScore;
            }
            else if (char.Equals(_winRules[playerShape], opponentShape))
            {
                return WinScore;
            }

            return LoseScore;
        }

        private int GetPlayerShapeScore(char playerShape)
        {
            switch(playerShape)
            {
                case Rock: return 1;
                case Paper: return 2;
                case Scissors: return 3;
                default: return 0;
            }
        }
    }
}
