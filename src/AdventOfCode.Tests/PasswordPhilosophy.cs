using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2020;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class PasswordPhilosophy
    {
        [Test]
        public void CheckPasswordPhilosophy()
        {
            IEnumerable<string> numbers = new List<string>() { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };

            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(numbers);

            var task = new Day2_PasswordPhilosophy(readListFromFile);
            var result = task.Execute(new List<string> { "" });

            Assert.AreEqual(result, "Part one: 2, Part two: 1");
        }
    }
}
