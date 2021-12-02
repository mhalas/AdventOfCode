using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2021;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2021
{
    [TestFixture]
    public class Dive
    {
        [Test]
        public void Part1_GetSimpleCalculations()
        {
            IEnumerable<string> actions = new List<string>() { "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2" };

            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(actions);

            var task = new Day2_Dive(readListFromFile);
            var result = task.Execute(new List<string> { "", "false" }).Result;

            Assert.AreEqual(result, "150");
        }

        [Test]
        public void Part2_GetAdvancedCalculations()
        {
            IEnumerable<string> actions = new List<string>() { "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2" };

            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(actions);

            var task = new Day2_Dive(readListFromFile);
            var result = task.Execute(new List<string> { "", "true" }).Result;

            Assert.AreEqual(result, "900");
        }
    }
}
