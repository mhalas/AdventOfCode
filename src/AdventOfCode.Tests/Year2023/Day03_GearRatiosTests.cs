using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2023;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2023
{
    [TestFixture]
    public class Day03_GearRatiosTests
    {
        [Test]
        public void Day03_GearRatiosTests_Part1()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598..",
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day03_GearRatios(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;
            Assert.AreEqual("4361", result);
        }

        [Test]
        public void Day03_GearRatiosTests_Part2()
        {
            IEnumerable<string> inputs = new List<string>()
            {

            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day03_GearRatios(readListFromFile);

            var result = task.Execute(new List<string> { "", "true" }).Result;
            Assert.AreEqual("", result);
        }
    }
}