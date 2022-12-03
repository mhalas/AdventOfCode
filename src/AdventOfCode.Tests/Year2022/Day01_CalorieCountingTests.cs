using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2022;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2022
{
    [TestFixture]
    public class Day01_CalorieCountingTests
    {
        [TestCase("1", "24000")]
        [TestCase("3", "45000")]
        public void Day01_CalorieCountingTests_Part1(string takeTopElfs, string expectedResult)
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "1000",
                "2000",
                "3000",
                "",
                "4000",
                "",
                "5000",
                "6000",
                "",
                "7000",
                "8000",
                "9000",
                "",
                "10000"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day01_CalorieCounting(readListFromFile);

            var result = task.Execute(new List<string> { "", takeTopElfs }).Result;
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}