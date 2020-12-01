using System.Collections.Generic;

namespace AdventOfCode.Shared.Contracts
{
    public interface IAdventTask
    {
        string Execute(IEnumerable<string> parameter);
    }
}
