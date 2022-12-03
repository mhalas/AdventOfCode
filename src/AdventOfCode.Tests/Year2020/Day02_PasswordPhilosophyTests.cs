using AdventOfCode.Shared.Contracts;
using AdventOfCode.Shared.Results;
using AdventOfCode.Tasks.Year2020;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2020
{
    [TestFixture]
    public class Day02_PasswordPhilosophyTests
    {
        [Test]
        public void CheckPasswordPhilosophy()
        {
            IEnumerable<string> numbers = new List<string>() { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };

            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(numbers);

            var task = new Day02_PasswordPhilosophy(readListFromFile);

            var result = JsonConvert.DeserializeObject<PasswordPhilosophyResult>(task.Execute(new List<string> { "" }).Result);
            Assert.AreEqual(2, result.CharactersCount);
            Assert.AreEqual(1, result.CharactersPositionCount);
        }
    }
}
