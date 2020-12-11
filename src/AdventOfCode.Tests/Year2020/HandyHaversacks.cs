using AdventOfCode.Shared.Contracts;
using AdventOfCode.Tasks.Year2020;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Year2020
{
    [TestFixture]
    public class HandyHaversacks
    {
        [Test]
        public void HandyHaversacks_HowManyBagColorsCanEventuallyContainYourBag()
        {
            IEnumerable<string> numbers = new List<string>()
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags.",
            };

            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(numbers);

            var task = new Day7_HandyHaversacks(readListFromFile);

            var result = task.Execute(new List<string> { "", "shiny gold" }).Result;
            Assert.AreEqual("4", result);

            result = task.Execute(new List<string> { "", "shiny gold", "false" }).Result;
            Assert.AreEqual("4", result);
        }

        [Test]
        public void HandyHaversacks_HowManyIndividualBagsAreREquiredInsideYOurSingleBag_1()
        {
            IEnumerable<string> numbers = new List<string>()
            {
                "shiny gold bags contain 2 dark red bags.",
                "dark red bags contain 2 dark orange bags.",
                "dark orange bags contain 2 dark yellow bags.",
                "dark yellow bags contain 2 dark green bags.",
                "dark green bags contain 2 dark blue bags.",
                "dark blue bags contain 2 dark violet bags.",
                "dark violet bags contain no other bags.",
            };

            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(numbers);

            var task = new Day7_HandyHaversacks(readListFromFile);

            var result = task.Execute(new List<string> { "", "shiny gold", "true" }).Result;
            Assert.AreEqual("126", result);
        }

        [Test]
        public void HandyHaversacks_HowManyIndividualBagsAreREquiredInsideYOurSingleBag_2()
        {
            IEnumerable<string> numbers = new List<string>()
            {
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags."
            };

            var readListFromFile = Substitute.For<IReadListFromFile>();
            readListFromFile.ReadFile("").Returns(numbers);

            var task = new Day7_HandyHaversacks(readListFromFile);

            var result = task.Execute(new List<string> { "", "shiny gold", "true" }).Result;
            Assert.AreEqual("32", result);
        }
    }
}
