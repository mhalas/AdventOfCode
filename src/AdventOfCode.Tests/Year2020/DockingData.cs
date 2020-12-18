using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2020;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2020
{
    [TestFixture]
    public class DockingData
    {
        [Test]
        public void DockingData_Part1()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                "mem[8] = 11",
                "mem[7] = 101",
                "mem[8] = 0",
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day14_DockingData(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;
            Assert.AreEqual("165", result);
        }

        [Test]
        public void DockingData_Part2()
        {
            IEnumerable<string> inputs = new List<string>()
            {

            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day14_DockingData(readListFromFile);

            var result = task.Execute(new List<string> { "", "true" }).Result;
            Assert.AreEqual("", result);
            Assert.Fail();
        }
    }
}