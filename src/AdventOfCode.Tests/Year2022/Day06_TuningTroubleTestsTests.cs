using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2022;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2022
{
    [TestFixture]
    public class Day06_TuningTroubleTestsTestsTests
    {
        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        public void Day06_TuningTrouble_Part1(string dataStream, int expectedResult)
        {
            IEnumerable<string> inputs = new List<string>()
            {
                dataStream
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day06_TuningTrouble(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;
            Assert.AreEqual(expectedResult, int.Parse(result));
        }

        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void Day06_TuningTrouble_Part2(string dataStream, int expectedResult)
        {
            IEnumerable<string> inputs = new List<string>()
            {
                dataStream
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day06_TuningTrouble(readListFromFile);

            var result = task.Execute(new List<string> { "", "14" }).Result;
            Assert.AreEqual(expectedResult, int.Parse(result));
        }
    }
}