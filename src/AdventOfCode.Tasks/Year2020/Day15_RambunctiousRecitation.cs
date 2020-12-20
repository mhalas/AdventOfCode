using AdventOfCode.Shared.Contracts;
using AdventOfCode.Shared.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AdventOfCode.Tasks.Year2020
{
    public class Day15_RambunctiousRecitation : IAdventTask
    {
        public Day15_RambunctiousRecitation()
        {

        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var part2 = false;
            var data = parameters.First().Split(',').Select(x=> long.Parse(x)).ToList();

            var dinnerTime = (long)2020;
            if (parameters.Count() == 2)
                dinnerTime = long.Parse(parameters.ElementAt(1));

            if (parameters.Count() == 2 && bool.TryParse(parameters.ElementAt(1), out bool isPart2))
                part2 = isPart2;

            var numbers = data.ToDictionary(x => x, x => new RambunctiousRecitationDto() { Turn = (long)data.IndexOf(x) + 1, Count = 1 });

            var turn = data.Count();
            var lastNumber = numbers.Last().Key;

            numbers.Remove(lastNumber);
            do
            {
                if (!numbers.ContainsKey(lastNumber))
                {
                    numbers.Add(lastNumber, new RambunctiousRecitationDto() { Turn = turn, Count = 1 });
                    lastNumber = 0;
                    continue;
                }

                var nextValue = turn - numbers[lastNumber].Turn;

                numbers[lastNumber].Count++;
                numbers[lastNumber].Turn = turn;

                lastNumber = nextValue;
            }
            while(turn++ < dinnerTime - 1);

            return Task.FromResult(lastNumber.ToString());
        }
    }
}
