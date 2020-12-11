using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2020;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2020
{
    [TestFixture]
    public class AdapterArray
    {
        [Test]
        public void AdapterArray_MultiplyResults_1()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "16",
                "10",
                "15",
                "5",
                "1",
                "11",
                "7",
                "19",
                "6",
                "12",
                "4"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day10_AdapterArray(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;
            Assert.AreEqual("35", result);
            result = task.Execute(new List<string> { "", "false" }).Result;
            Assert.AreEqual("35", result);
        }

        [Test]
        public void AdapterArray_MultiplyResults_2()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "28",
                "33",
                "18",
                "42",
                "31",
                "14",
                "46",
                "20",
                "48",
                "47",
                "24",
                "23",
                "49",
                "45",
                "19",
                "38",
                "39",
                "11",
                "1",
                "32",
                "25",
                "35",
                "8",
                "17",
                "7",
                "9",
                "4",
                "2",
                "34",
                "10",
                "3"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day10_AdapterArray(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;
            Assert.AreEqual("220", result);

            result = task.Execute(new List<string> { "", "false" }).Result;
            Assert.AreEqual("220", result);
        }

        [Test]
        public void AdapterArray_GetArragements_1()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "16",
                "10",
                "15",
                "5",
                "1",
                "11",
                "7",
                "19",
                "6",
                "12",
                "4"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day10_AdapterArray(readListFromFile);

            var result = task.Execute(new List<string> { "", "true" }).Result;
            Assert.AreEqual("8", result);
        }

        [Test]
        public void AdapterArray_GetArragements_2()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "28",
                "33",
                "18",
                "42",
                "31",
                "14",
                "46",
                "20",
                "48",
                "47",
                "24",
                "23",
                "49",
                "45",
                "19",
                "38",
                "39",
                "11",
                "1",
                "32",
                "25",
                "35",
                "8",
                "17",
                "7",
                "9",
                "4",
                "2",
                "34",
                "10",
                "3"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day10_AdapterArray(readListFromFile);

            var result = task.Execute(new List<string> { "", "true" }).Result;
            Assert.AreEqual("19208", result);
        }
    }
}
