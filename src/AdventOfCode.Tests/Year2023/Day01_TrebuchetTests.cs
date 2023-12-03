using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2023;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2023
{
    [TestFixture]
    public class Day01_TrebuchetTests
    {
        [Test]
        public void Day01_TrebuchetTests_Part1()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "1abc2",
                "pqr3stu8vwx",
                "a1b2c3d4e5f",
                "treb7uchet",
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day01_Trebuchet(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;
            Assert.AreEqual("142", result);
        }

        [Test]
        public void Day01_TrebuchetTests_Part2()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "two1nine",
                "eightwothree",
                "abcone2threexyz",
                "xtwone3four",
                "4nineeightseven2",
                "zoneight234",
                "7pqrstsixteen",

                "eightwo"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day01_Trebuchet(readListFromFile);

            var result = task.Execute(new List<string> { "", "true" }).Result;
            Assert.AreEqual("363", result);
        }
    }
}