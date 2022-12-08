using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2022;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2022
{
    [TestFixture]
    public class Day03_RucksackReorganizationTests
    {
        [Test]
        public void Day03_RucksackReorganization_Part1()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "vJrwpWtwJgWrhcsFMMfFFhFp",
                "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                "PmmdzqPrVvPwwTWBwg",
                "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                "ttgJtRGJQctTZtZT",
                "CrZsJsPPZsGzwwsLwLmpwMDw",
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day03_RucksackReorganization(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;
            Assert.AreEqual("157", result);
        }

        [Test]
        public void Day03_RucksackReorganization_Part2()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "vJrwpWtwJgWrhcsFMMfFFhFp",
                "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                "PmmdzqPrVvPwwTWBwg",
                "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                "ttgJtRGJQctTZtZT",
                "CrZsJsPPZsGzwwsLwLmpwMDw",
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day03_RucksackReorganization(readListFromFile);

            var result = task.Execute(new List<string> { "", "3" }).Result;
            Assert.AreEqual("70", result);
        }
    }
}