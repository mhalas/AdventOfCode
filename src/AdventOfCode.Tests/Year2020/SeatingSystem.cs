using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2020;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2020
{
    [TestFixture]
    public class SeatingSystem
    {
        [Test]
        public void SeatingSystem_GetOccupiedSeats()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "L.LL.LL.LL",
                "LLLLLLL.LL",
                "L.L.L..L..",
                "LLLL.LL.LL",
                "L.LL.LL.LL",
                "L.LLLLL.LL",
                "..L.L.....",
                "LLLLLLLLLL",
                "L.LLLLLL.L",
                "L.LLLLL.LL"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day11_SeatingSystem(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;
            Assert.AreEqual("37", result);
            result = task.Execute(new List<string> { "", "4" }).Result;
            Assert.AreEqual("37", result);
        }

        [Test]
        public void AdapterArray_GetAdvancedOccupiedSeats()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "L.LL.LL.LL",
                "LLLLLLL.LL",
                "L.L.L..L..",
                "LLLL.LL.LL",
                "L.LL.LL.LL",
                "L.LLLLL.LL",
                "..L.L.....",
                "LLLLLLLLLL",
                "L.LLLLLL.L",
                "L.LLLLL.LL"
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day11_SeatingSystem(readListFromFile);

            var result = task.Execute(new List<string> { "", "5", "true" }).Result;
            Assert.AreEqual("26", result);
        }

        [Test]
        public void AdapterArray_CheckTemp()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                ".##.##.",
                "#.#.#.#",
                "##...##",
                "...L...",
                "##...##",
                "#.#.#.#",
                ".##.##."
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day11_SeatingSystem(readListFromFile);

            var result = task.Execute(new List<string> { "", "5", "true" }).Result;
            Assert.AreEqual("9", result);
        }
    }
}
