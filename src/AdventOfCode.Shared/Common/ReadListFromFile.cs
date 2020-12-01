using AdventOfCode.Shared.Contracts;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Shared.Common
{
    public class ReadListFromFile: IReadListFromFile
    {
        public IEnumerable<string> ReadFile(string path)
        {
            if (string.IsNullOrEmpty(path))
                return new List<string>();

            return File.ReadAllLines(path);
        }
    }
}
