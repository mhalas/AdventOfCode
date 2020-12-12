using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2020;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2020
{
    [TestFixture]
    public class RainRisk
    {
        [Test]
        public void RainRisk_GetManhattanDistance()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "F10",
                "N3",
                "F7",
                "R90",
                "F11"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day12_RainRisk(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;
            Assert.AreEqual("25", result);
        }

        [Test]
        public void RainRisk_GetManhattanDistance_Part2()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "F10",
                "N3",
                "F7",
                "R90",
                "F11"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day12_RainRisk(readListFromFile);

            var result = task.Execute(new List<string> { "", "true", "1", "10" }).Result;
            Assert.AreEqual("286", result);
        }
    }
}
