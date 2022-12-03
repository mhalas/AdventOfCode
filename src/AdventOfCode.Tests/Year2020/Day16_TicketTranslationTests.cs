using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2020;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2020
{
    [TestFixture]
    public class Day16_TicketTranslationTests
    {
        [Test]
        public void TicketTranslation_Part1()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "class: 1-3 or 5-7",
                "row: 6-11 or 33-44",
                "seat: 13-40 or 45-50",
                "",
                "your ticket:",
                "7,1,14",
                "",
                "nearby tickets:",
                "7,3,47",
                "40,4,50",
                "55,2,20",
                "38,6,12"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day16_TicketTranslation(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;
            Assert.AreEqual("71", result);
        }

        [Ignore("Not Implemented Part2")]
        public void TicketTranslation_Part2()
        {
            IEnumerable<string> inputs = new List<string>()
            {

            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day16_TicketTranslation(readListFromFile);

            var result = task.Execute(new List<string> { "", "true" }).Result;
            Assert.AreEqual("", result);
        }
    }
}