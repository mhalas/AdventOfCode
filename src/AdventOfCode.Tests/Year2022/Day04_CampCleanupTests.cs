using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2022;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2022
{
    [TestFixture]
    public class Day04_CampCleanupTests
    {
        [Test]
        public void Day04_CampCleanup_Part1()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "2-4,6-8",
                "2-3,4-5",
                "5-7,7-9",
                "2-8,3-7",
                "6-6,4-6",
                "2-6,4-8"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day04_CampCleanup(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;
            Assert.AreEqual("2", result);
        }

        [Test]
        public void Day04_CampCleanup_Part2()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "2-4,6-8",
                "2-3,4-5",
                "5-7,7-9",
                "2-8,3-7",
                "6-6,4-6",
                "2-6,4-8"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day04_CampCleanup(readListFromFile);

            var result = task.Execute(new List<string> { "", "true" }).Result;
            Assert.AreEqual("4", result);
        }
    }
}