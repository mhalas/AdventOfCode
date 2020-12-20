using AdventOfCode.Tasks.Year2020;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2020
{
    [TestFixture]
    public class RambunctiousRecitation
    {
        [TestCase("0,3,6", "436")]
        [TestCase("1,3,2", "1")]
        [TestCase("2,1,3", "10")]
        [TestCase("1,2,3", "27")]
        [TestCase("2,3,1", "78")]
        [TestCase("3,2,1", "438")]
        [TestCase("3,1,2", "1836")]
        public void RambunctiousRecitation_Part1(string numbers, string expected)
        {
            var task = new Day15_RambunctiousRecitation();

            var result = task.Execute(new List<string> { numbers, "2020" }).Result;
            Assert.AreEqual(expected, result);
        }

        [TestCase("0,3,6", "175594")]
        [TestCase("1,3,2", "2578")]
        [TestCase("2,1,3", "3544142")]
        [TestCase("1,2,3", "261214")]
        [TestCase("2,3,1", "6895259")]
        [TestCase("3,2,1", "18")]
        [TestCase("3,1,2", "362")]
        public void RambunctiousRecitation_Part2(string numbers, string expected)
        {
            var task = new Day15_RambunctiousRecitation();

            var result = task.Execute(new List<string> { numbers, "30000000" }).Result;
            Assert.AreEqual(expected, result);
        }
    }
}