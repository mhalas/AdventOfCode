using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventOfCode.Shared.Contracts
{
    public interface IAdventTask
    {
        Task<string> Execute(IEnumerable<string> parameters);
    }
}
