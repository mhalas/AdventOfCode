using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2020;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2020
{
    [TestFixture]
    public class Day01_ReportRepairTests
    {
        [Test]
        public void CheckReportRepair_2numbers()
        {
            IEnumerable<string> numbers = new List<string>() { "1721", "979", "366", "299", "675", "1456" };

            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(numbers);

            var task = new Day01_ReportRepair(readListFromFile);
            var result = task.Execute(new List<string> { "", "2" }).Result;

            Assert.AreEqual(result, "514579");
        }

        [Test]
        public void CheckReportRepair_3numbers()
        {
            IEnumerable<string> numbers = new List<string>() { "1721", "979", "366", "299", "675", "1456" };

            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(numbers);

            var task = new Day01_ReportRepair(readListFromFile);
            var result = task.Execute(new List<string> { "", "3" }).Result;

            Assert.AreEqual(result, "241861950");
        }
    }
}