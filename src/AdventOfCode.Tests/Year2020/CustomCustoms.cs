using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2020;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2020
{
    [TestFixture]
    public class CustomCustoms
    {
        [Test]
        public void CustomCustoms_CountAllAnswersFromGroup()
        {
            IEnumerable<string> inputs = new List<string>() 
            {
                "abc",
                "",
                "a",
                "b",
                "c",
                "",
                "ab",
                "ac",
                "",
                "a",
                "a",
                "a",
                "a",
                "",
                "b"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day6_CustomCustoms(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;
            Assert.AreEqual("11", result);

            result = task.Execute(new List<string> { "", "False" }).Result;
            Assert.AreEqual("11", result);
        }

        [Test]
        public void CustomCustoms_CountTheSameAnswersInGroup()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "abc",
                "",
                "a",
                "b",
                "c",
                "",
                "ab",
                "ac",
                "",
                "a",
                "a",
                "a",
                "a",
                "",
                "b"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day6_CustomCustoms(readListFromFile);

            var result = task.Execute(new List<string> { "", "true" }).Result;
            Assert.AreEqual("6", result);
        }
    }
}
