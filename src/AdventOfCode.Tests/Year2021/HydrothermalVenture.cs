using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2021;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2021
{
    [TestFixture]
    public class HydrothermalVenture
    {
        [Test]
        public void HydrothermalVenture_Part1()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "0,9 -> 5,9",
                "8,0 -> 0,8",
                "9,4 -> 3,4",
                "2,2 -> 2,1",
                "7,0 -> 7,4",
                "6,4 -> 2,0",
                "0,9 -> 2,9",
                "3,4 -> 1,4",
                "0,0 -> 8,8",
                "5,5 -> 8,2"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day5_HydrothermalVenture(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;
            Assert.AreEqual("", result);
        }

        [Test]
        public void HydrothermalVenture_Part2()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "0,9 -> 5,9",
                "8,0 -> 0,8",
                "9,4 -> 3,4",
                "2,2 -> 2,1",
                "7,0 -> 7,4",
                "6,4 -> 2,0",
                "0,9 -> 2,9",
                "3,4 -> 1,4",
                "0,0 -> 8,8",
                "5,5 -> 8,2"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day5_HydrothermalVenture(readListFromFile);

            var result = task.Execute(new List<string> { "", "true" }).Result;
            Assert.AreEqual("", result);
        }
    }
}