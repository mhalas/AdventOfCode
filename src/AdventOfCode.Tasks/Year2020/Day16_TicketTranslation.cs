using AdventOfCode.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode.Tasks.Year2020
{
    public class Day16_TicketTranslation : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day16_TicketTranslation(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var part2 = false;
            var data = _readListFromFile.ReadFile(parameters.First()).ToList();

            if (parameters.Count() == 2 && bool.TryParse(parameters.ElementAt(1), out bool isPart2))
                part2 = isPart2;

            var ticket = DeserializeTicket(data);

            var ticketScanningErrorRate = GetErrorRate(ticket);

            return Task.FromResult(ticketScanningErrorRate.ToString());
        }

        private int GetErrorRate(Dictionary<string, List<int>> ticket)
        {
            var notIncludeLabels = new string[] { "your ticket", "nearby tickets" }.ToList();
            var result = ticket["nearby tickets"].AsEnumerable();

            foreach (var ticketData in ticket.Where(x => !notIncludeLabels.Contains(x.Key)))
            {
                result = result.Where(x => !ticketData.Value.Any(y => y == x));
            }

            return result.Sum();
        }

        private Dictionary<string, List<int>> DeserializeTicket(List<string> data)
        {
            var result = new Dictionary<string, List<int>>();
            var currentLabel = string.Empty;

            foreach (var row in data.Where(x => !string.IsNullOrEmpty(x)))
            {
                var keyValue = row.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

                if (keyValue[0] == "your ticket" || keyValue[0] == "nearby tickets")
                {
                    currentLabel = keyValue[0];
                    result.Add(currentLabel, new List<int>());
                }
                else if (!string.IsNullOrEmpty(currentLabel))
                {
                    result[currentLabel].AddRange(keyValue[0].Split(',').Select(x => int.Parse(x)));
                    result[currentLabel].Sort();
                }
                else
                {
                    var ranges = keyValue[1].Split(new string[] { " or " }, StringSplitOptions.None);
                    var numbers = GetNumbers(ranges);
                    result.Add(keyValue[0], numbers);

                }
            }

            return result;
        }

        private List<int> GetNumbers(string[] ranges)
        {
            var result = new List<int>();

            foreach (var r in ranges)
            {
                var numbersBetween = r.Replace(" ", string.Empty).Split('-').Select(x => int.Parse(x));
                for (int i = numbersBetween.ElementAt(0); i <= numbersBetween.ElementAt(1); i++)
                    result.Add(i);
            }

            return result;
        }
    }
}
