using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2021;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2021
{
    [TestFixture]
    public class Day03_BinaryDiagnosticTests
    {
        [Test]
        public void BinaryDiagnostic_Part1()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day03_BinaryDiagnostic(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;
            Assert.AreEqual("198", result);
        }

        [Test]
        public void BinaryDiagnostic_Part2()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day03_BinaryDiagnostic(readListFromFile);

            var result = task.Execute(new List<string> { "", "true" }).Result;
            Assert.AreEqual("230", result);
        }
    }
}