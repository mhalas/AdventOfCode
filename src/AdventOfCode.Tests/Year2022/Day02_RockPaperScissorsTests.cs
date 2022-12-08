using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2022;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2022
{
    [TestFixture]
    public class Day02_RockPaperScissorsTests
    {
        [Test]
        public void Day02_RockPaperScissors_Part1()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "A Y",
                "B X",
                "C Z"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day02_RockPaperScissors(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;
            Assert.AreEqual("15", result);
        }

        [Test]
        public void Day02_RockPaperScissors_Part2()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "A Y",
                "B X",
                "C Z"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day02_RockPaperScissors(readListFromFile);

            var result = task.Execute(new List<string> { "", "true" }).Result;
            Assert.AreEqual("12", result);
        }
    }
}