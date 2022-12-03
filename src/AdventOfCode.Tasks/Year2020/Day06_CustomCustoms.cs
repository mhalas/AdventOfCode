using AdventOfCode.Shared.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Tasks.Year2020
{
    public class Day06_CustomCustoms: IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day06_CustomCustoms(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var data = _readListFromFile.ReadFile(parameters.First());
            bool countOnlyTheSameAnswers = false;
            if(parameters.Count() == 2 && bool.TryParse(parameters.ElementAt(1), out bool secondArgument))
            {
                countOnlyTheSameAnswers = secondArgument;
            }

            var result = GetCountOfYesAnswers(data, countOnlyTheSameAnswers);

            return Task.FromResult(result.ToString());
        }

        private int GetCountOfYesAnswers(IEnumerable<string> data, bool countOnlyTheSameAnswers)
        {
            var counts = new List<int>();

            List<string> tempCurrentAnswers = new List<string>();
            foreach (var row in data)
            {
                if (string.IsNullOrEmpty(row))
                {
                    counts.Add(CountGroup(tempCurrentAnswers, countOnlyTheSameAnswers));

                    tempCurrentAnswers.Clear();
                }
                else
                {
                    tempCurrentAnswers.Add(row);
                }
            }
            counts.Add(CountGroup(tempCurrentAnswers, countOnlyTheSameAnswers));

            return counts.Sum();
        }

        private int CountGroup(List<string> tempCurrentAnswers, bool countOnlyTheSameAnswers)
        {
            if(!countOnlyTheSameAnswers)
                return string
                    .Concat(tempCurrentAnswers)
                    .Distinct()
                    .Count();


            var intersectedList = tempCurrentAnswers.First();
            foreach (var answers in tempCurrentAnswers)
            {
                intersectedList = new string(intersectedList.Intersect(answers).ToArray());
            }

            return intersectedList.Count();
        }
    }
}
