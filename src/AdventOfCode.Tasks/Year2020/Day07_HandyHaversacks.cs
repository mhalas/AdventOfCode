using AdventOfCode.Shared.Contracts;
using AdventOfCode.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Tasks.Year2020
{
    public class Day07_HandyHaversacks : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day07_HandyHaversacks(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            if (parameters.Count() < 2)
                return Task.FromResult("Error, please pass color as 4th argument.");
            var searchingBagColor = parameters.ElementAt(1);

            var goDeeper = false;
            if (parameters.Count() == 3)
                goDeeper = bool.Parse(parameters.ElementAt(2));

            var data = _readListFromFile.ReadFile(parameters.First());
            var bagDefinitions = DeserializeBags(data);

            if (goDeeper)
                return Task.FromResult(CalculateIndividualBags(bagDefinitions, searchingBagColor).ToString());

            return Task.FromResult(CalculateBags(bagDefinitions, searchingBagColor, new List<HandyHaversacksBagDto>(), 0).ToString());
        }

        private int CalculateIndividualBags(IEnumerable<HandyHaversacksBagDto> bagDefinitions, string searchingBagColor)
        {
            var parentBag = bagDefinitions.Single(x => x.BagColor == searchingBagColor);
            if (!parentBag.Children.Any())
                return 1;

            int result = 0;
            foreach (var childBag in parentBag.Children)
            {
                var childBagsCount = CalculateIndividualBags(bagDefinitions, childBag.BagColor);

                if (childBagsCount == 1)
                    result += childBag.NumberOfBags.Value * childBagsCount;
                else
                    result += childBag.NumberOfBags.Value + childBag.NumberOfBags.Value * childBagsCount;
            }

            return result;
        }

        private int CalculateBags(IEnumerable<HandyHaversacksBagDto> bagDefinitions, string searchingBagColor, List<HandyHaversacksBagDto> alreadyVisited, int sum)
        {
            var parentBags = bagDefinitions.Where(x => x.Children.Any(y => y.BagColor == searchingBagColor));

            foreach (var bag in parentBags.Where(x => !alreadyVisited.Any(y => y.BagColor == x.BagColor)))
            {
                sum += CalculateBags(bagDefinitions, bag.BagColor, alreadyVisited, 1);
                alreadyVisited.Add(bag);
            }

            return sum;
        }

        private IEnumerable<HandyHaversacksBagDto> DeserializeBags(IEnumerable<string> data)
        {
            List<HandyHaversacksBagDto> bags = new List<HandyHaversacksBagDto>();

            foreach (var item in data)
            {
                var containSplit = item.Split(new string[] { "contain " }, StringSplitOptions.RemoveEmptyEntries);
                var parentBag = DeserializeSingleBag(containSplit[0]);
                var childrenBags = containSplit[1].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var childBag in childrenBags)
                {
                    var bag = DeserializeSingleBag(childBag);

                    if(bag != null)
                        parentBag.Children.Add(bag);
                }

                bags.Add(parentBag);
            }

            return bags;
        }

        private HandyHaversacksBagDto DeserializeSingleBag(string childBag)
        {
            var spaceSplit = childBag.Split(' ');

            if (int.TryParse(spaceSplit[0], out int count))
            {
                return new HandyHaversacksBagDto($"{spaceSplit[1]} {spaceSplit[2]}", count);
            }
            else if (spaceSplit[0] == "no")
            {
                return null;
            }
            else
            {
                return new HandyHaversacksBagDto($"{spaceSplit[0]} {spaceSplit[1]}");
            }
        }
    }
}
