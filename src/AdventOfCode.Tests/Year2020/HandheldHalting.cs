using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2020;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Tests.Year2020
{
    [TestFixture]
    public class HandheldHalting
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

            var task = new Day8_HandheldHalting(readListFromFile);

            var result = task.Execute(new List<string> { "", "false" });
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

            var task = new Day8_HandheldHalting(readListFromFile);

            var result = task.Execute(new List<string> { "" });
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

            var task = new Day8_HandheldHalting(readListFromFile);

            var result = task.Execute(new List<string> { "", "true" });
            Assert.AreEqual("8", result);
        }
    }
}
