using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2020;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2020
{
    [TestFixture]
    public class Day08_HandheldHaltingTests
    {
        [Test]
        public void HandheldHalting_FindAccValueBeforeSecondLoop_1()
        {
            IEnumerable<string> numbers = new List<string>()
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6",
            };

            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(numbers);

            var task = new Day08_HandheldHalting(readListFromFile);

            var result = task.Execute(new List<string> { "", "false" }).Result;
            Assert.AreEqual("5", result);
        }

        [Test]
        public void HandheldHalting_FindAccValueBeforeSecondLoop_2()
        {
            IEnumerable<string> numbers = new List<string>()
            {
                "nop +0",
                "acc +1",
                "nop +1",
                "acc +1",
                "nop +2",
                "acc +1",
                "nop +1000",
                "acc +1",

                "jmp +1",

                "nop +0",
                "acc +1",
                "nop +1",
                "acc +1",
                "nop +2",
                "acc +1",
                "nop +1000",
                "acc -1",

                "jmp -10",

                "nop +0",
                "acc +1",
                "nop +1",
                "acc +1",
                "nop +2",
                "acc +1",
                "nop +1000",
                "acc +1",

            };

            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(numbers);

            var task = new Day08_HandheldHalting(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;
            Assert.AreEqual("6", result);
        }

        [Test]
        public void HandheldHalting_FindAccValueBeforeSecondLoop_Fix()
        {
            IEnumerable<string> numbers = new List<string>()
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6",
            };

            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(numbers);

            var task = new Day08_HandheldHalting(readListFromFile);

            var result = task.Execute(new List<string> { "", "true" }).Result;
            Assert.AreEqual("8", result);
        }
    }
}
