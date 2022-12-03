using AdventOfCode.Shared.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AdventOfCode.Tasks.Year2022
{
    public class Day01_CalorieCounting : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day01_CalorieCounting(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            int sumTopElfsCount = 1;
            if(parameters != null && parameters.Count() == 2 
                && int.TryParse(parameters.ElementAt(1), out int param1))
            {
                sumTopElfsCount = param1;
            }

            var data = _readListFromFile.ReadFile(parameters.First()).ToList();

            var elfsWithMaxCaloriesCarried = string
                .Join(",", data)
                .Split(new string[] { ",," }, System.StringSplitOptions.None)
                .Select(x => x.Split(',').Select(y => int.Parse(y)).Sum())
                .OrderBy(x => x);

            var sumTopElfs = elfsWithMaxCaloriesCarried
                .Skip(elfsWithMaxCaloriesCarried.Count() - sumTopElfsCount)
                .Sum();

            return Task.FromResult(sumTopElfs.ToString());
        }
    }
}
