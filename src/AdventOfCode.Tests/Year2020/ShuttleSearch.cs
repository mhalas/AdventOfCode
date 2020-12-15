using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2020;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2020
{
    [TestFixture]
    public class ShuttleSearch
    {
        [TestCase("939", "7,13,x,x,59,x,31,19")]
        public void ShuttleSearch_CheckAnswer(string timestamp, string buses)
        {
            IEnumerable<string> inputs = new List<string>()
            {
                timestamp,
                buses
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day13_ShuttleSearch(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;
            Assert.AreEqual("295", result);
        }

        [TestCase("7,13,x,x,59,x,31,19", "1068781")]
        [TestCase("17,x,13,19", "3417")]
        [TestCase("67,7,59,61", "754018")]
        [TestCase("67,x,7,59,61", "779210")]
        [TestCase("67,7,x,59,61", "1261476")]
        [TestCase("1789,37,47,1889", "1202161486")]
        public void ShuttleSearch_CheckAnswer_Part2(string buses, string expectedResult)
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "x",
                buses
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day13_ShuttleSearch(readListFromFile);

            var result = task.Execute(new List<string> { "", "true" }).Result;
            Assert.AreEqual(expectedResult, result);
        }
    }
}
