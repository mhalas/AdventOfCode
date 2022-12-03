using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2021;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2021
{
    [TestFixture]
    public class Day01_SonarSweepTests
    {
        [Test]
        public void Part1_CheckIncreasedValues()
        {
            IEnumerable<string> numbers = new List<string>() { "199", 
                "200",
                "208",
                "210",
                "200",
                "207",
                "240",
                "269",
                "260",
                "263" };

            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(numbers);

            var task = new Day1_SonarSweep(readListFromFile);
            var result = task.Execute(new List<string> { "" }).Result;

            Assert.AreEqual(result, "7");

            result = task.Execute(new List<string> { "", "1" }).Result;
            Assert.AreEqual(result, "7");
        }

        [Test]
        public void Part2_CheckIncreasedValuesWithGroups()
        {
            IEnumerable<string> numbers = new List<string>() { "199",
                "200",
                "208",
                "210",
                "200",
                "207",
                "240",
                "269",
                "260",
                "263" };

            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(numbers);

            var task = new Day1_SonarSweep(readListFromFile);
            var result = task.Execute(new List<string> { "", "3" }).Result;

            Assert.AreEqual(result, "5");
        }
    }
}
