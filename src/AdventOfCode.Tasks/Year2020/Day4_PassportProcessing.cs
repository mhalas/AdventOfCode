using AdventOfCode.Shared.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Tasks.Year2020
{
    public class Day4_PassportProcessing: IAdventTask
    {
        private IEnumerable<string> _validEyeColors = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
        private string _hairColorRegex = "#([0-9a-f]{6})";

        private IReadListFromFile _readListFromFile;

        public Day4_PassportProcessing(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public string Execute(IEnumerable<string> parameters)
        {
            var checkEachField = false;
            var data = _readListFromFile.ReadFile(parameters.First());

            if (parameters.Count() == 2)
                checkEachField = bool.Parse(parameters.ElementAt(1));

            var passports = GetPassports(data);
            var result = ValidatePassports(passports, checkEachField);

            return result.ToString();
        }

        private int ValidatePassports(List<Dictionary<string, string>> passports, bool checkEachField)
        {
            var passportsWithRequiredFields = passports.Where(x => x.Keys.Count() == 8 || (x.Keys.Count() == 7 && !x.Keys.Any(y => y == "cid")));

            if (!checkEachField)
                return passportsWithRequiredFields.Count();

            return passportsWithRequiredFields
                .Count(p => 
                    p.Any(x => x.Key == "byr" && int.Parse(x.Value) >= 1920 && int.Parse(x.Value) <= 2002) &&
                    p.Any(x => x.Key == "iyr" && int.Parse(x.Value) >= 2010 && int.Parse(x.Value) <= 2020) &&
                    p.Any(x => x.Key == "eyr" && int.Parse(x.Value) >= 2020 && int.Parse(x.Value) <= 2030) &&
                    p.Any(x => x.Key == "hgt" && CheckHeight(x.Value)) &&
                    p.Any(x => x.Key == "hcl" && Regex.IsMatch(x.Value, _hairColorRegex)) &&
                    p.Any(x => x.Key == "ecl" && _validEyeColors.Contains(x.Value)) &&
                    p.Any(x => x.Key == "pid" && x.Value.Length == 9 && int.TryParse(x.Value, out int pid)));

            bool CheckHeight(string v)
            {
                if ((v.Contains("cm")
                    && v.Length == 5
                    && int.TryParse(v.Substring(0, 3), out int cm)
                    && cm >= 150
                    && cm <= 193)
                    ||
                    (v.Contains("in")
                    && v.Length == 4
                    && int.TryParse(v.Substring(0, 2), out int inch)
                    && inch >= 59
                    && inch <= 76))
                {
                    return true;
                }

                return false;
            }
        }

        private List<Dictionary<string, string>> GetPassports(IEnumerable<string> data)
        {
            List<Dictionary<string, string>> passports = new List<Dictionary<string, string>>();

            List<string> tempPassport = new List<string>();
            foreach (var row in data)
            {
                if (string.IsNullOrEmpty(row))
                {
                    passports.Add(CreateNewPassport(string.Join(" ", tempPassport)));
                    tempPassport.Clear();
                }
                else
                {
                    tempPassport.Add(row);
                }
            }
            passports.Add(CreateNewPassport(string.Join(" ", tempPassport)));

            return passports;
        }

        private Dictionary<string, string> CreateNewPassport(string tempPassport)
        {
            return tempPassport
                .Split(' ')
                .Select(x => x.Split(':'))
                .ToDictionary(x => x[0], x => x[1]);
        }
    }
}
