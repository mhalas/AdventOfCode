using AdventOfCode.Shared.Contracts;
using AdventOfCode.Shared.Results;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Tasks.Year2020
{
    public class Day2_PasswordPhilosophy : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day2_PasswordPhilosophy(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public string Execute(IEnumerable<string> parameter)
        {
            var path = parameter.First();
            var data = _readListFromFile.ReadFile(path);

            return JsonConvert.SerializeObject(GetCount(data));
        }

        private PasswordPhilosophyResult GetCount(IEnumerable<string> data)
        {
            var dataPair = data.Select(x => x.Split(':'));

            int resultCharactersCount = 0;
            int resultCharactersPositionCount = 0;
            foreach (var row in dataPair)
            {
                var password = row[1];

                var policy = row[0].Split(' ');
                var minMaxPair = policy[0].Split('-').Select(x=> int.Parse(x)).ToList();
                var character = policy[1].ToCharArray().First();

                var characterCount = password.Where(x => x == character).Count();

                if (characterCount >= minMaxPair[0] && characterCount <= minMaxPair[1])
                    resultCharactersCount++;

                if (password[minMaxPair[0]] == character ^ password[minMaxPair[1]] == character)
                    resultCharactersPositionCount++;
            }

            return new PasswordPhilosophyResult(resultCharactersCount, resultCharactersPositionCount);
        }
    }
}