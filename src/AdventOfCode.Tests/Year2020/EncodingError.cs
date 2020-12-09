using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2020;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2020
{
    [TestFixture]
    public class EncodingError
    {
        [Test]
        public void EncodingError_GetInvalidNumber()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "35",
                "20",
                "15",
                "25",
                "47",
                "40",
                "62",
                "55",
                "65",
                "95",
                "102",
                "117",
                "150",
                "182",
                "127",
                "219",
                "299",
                "277",
                "309",
                "576",
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day9_EncodingError(readListFromFile);

            var result = task.Execute(new List<string> { "", "5" });
            Assert.AreEqual("127", result);

            result = task.Execute(new List<string> { "", "5", "false" });
            Assert.AreEqual("127", result);
        }

        [Test]
        public void EncodingError_FindEncryptionWeakness()
        {
            IEnumerable<string> inputs = new List<string>()
            {
                "35",
                "20",
                "15",
                "25",
                "47",
                "40",
                "62",
                "55",
                "65",
                "95",
                "102",
                "117",
                "150",
                "182",
                "127",
                "219",
                "299",
                "277",
                "309",
                "576",
            };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day9_EncodingError(readListFromFile);

            var result = task.Execute(new List<string> { "", "5", "true" });
            Assert.AreEqual("62", result);
        }
    }
}
