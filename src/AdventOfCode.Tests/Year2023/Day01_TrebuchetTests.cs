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
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day01_Trebuchet(readListFromFile);

            var result = task.Execute(new List<string> { "", "true" }).Result;
            Assert.AreEqual("281", result);
        }

        [TestCase("34", 34)]
        [TestCase("eightwo", 82)]
        [TestCase("eightwothree", 83)]
        [TestCase("eighthree", 83)]
        [TestCase("sevenine", 79)]
        [TestCase("twone", 21)]
        [TestCase("7one7", 77)]
        [TestCase("sevenx1xseven", 77)]

        [TestCase("1one", 11)]
        [TestCase("2two", 22)]
        [TestCase("3three", 33)]
        [TestCase("4four", 44)]
        [TestCase("5five", 55)]
        [TestCase("6six", 66)]
        [TestCase("7seven", 77)]
        [TestCase("8eight", 88)]
        [TestCase("9nine", 99)]

        [TestCase("one1", 11)]
        [TestCase("two2", 22)]
        [TestCase("three3", 33)]
        [TestCase("four4", 44)]
        [TestCase("five5", 55)]
        [TestCase("six6", 66)]
        [TestCase("seven7", 77)]
        [TestCase("eight8", 88)]
        [TestCase("nine9", 99)]

        [TestCase("1", 11)]
        [TestCase("2", 22)]
        [TestCase("3", 33)]
        [TestCase("4", 44)]
        [TestCase("5", 55)]
        [TestCase("6", 66)]
        [TestCase("7", 77)]
        [TestCase("8", 88)]
        [TestCase("9", 99)]
        [TestCase("one", 11)]
        [TestCase("two", 22)]
        [TestCase("three", 33)]
        [TestCase("four", 44)]
        [TestCase("five", 55)]
        [TestCase("six", 66)]
        [TestCase("seven", 77)]
        [TestCase("eight", 88)]
        [TestCase("nine", 99)]
        public void Day01_TrebuchetTests_CheckSingleRows(string input, int expectedResult)
        {
            IEnumerable<string> inputs = new List<string>()
            {
                input
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day01_Trebuchet(readListFromFile);

            var result = task.Execute(new List<string> { "", "true" }).Result;
            Assert.AreEqual(expectedResult.ToString(), result);
        }
    }
}