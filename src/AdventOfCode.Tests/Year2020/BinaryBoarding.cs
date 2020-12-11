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
    public class BinaryBoarding
    {
        [TestCase("FBFBBFFRLR", 44, 5, 357)]
        [TestCase("BFFFBBFRRR", 70, 7, 567)]
        [TestCase("FFFBBBFRRR", 14, 7, 119)]
        [TestCase("BBFFBBFRLL", 102, 4, 820)]
        public void CheckSinglePassportProcessing(string binaryValue, int row, int Column, int seatId)
        {
            IEnumerable<string> inputs = new List<string>() { binaryValue };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day5_BinaryBoarding(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;

            var dto = JsonConvert.DeserializeObject<BinaryBoardingResult>(result);
            Assert.AreEqual(row, dto.HighestBoarding.Row);
            Assert.AreEqual(Column, dto.HighestBoarding.Column);
            Assert.AreEqual(seatId, dto.HighestBoarding.SeatId);
        }

        [Test]
        public void GetHighestPassportProcessingInput()
        {
            IEnumerable<string> inputs = new List<string>() { "FBFBBFFRLR", "BFFFBBFRRR", "FFFBBBFRRR", "BBFFBBFRLL" };
            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(inputs);

            var task = new Day5_BinaryBoarding(readListFromFile);

            var result = task.Execute(new List<string> { "" }).Result;

            var dto = JsonConvert.DeserializeObject<BinaryBoardingResult>(result);
            Assert.AreEqual("BBFFBBFRLL", dto.HighestBoarding.BinaryValue);
        }
    }
}
