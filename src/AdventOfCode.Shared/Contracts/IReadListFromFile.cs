using System.Collections.Generic;

namespace AdventOfCode.Shared.Contracts
{
    public interface IReadListFromFile
    {
        IEnumerable<string> ReadFile(string path);
    }
}
