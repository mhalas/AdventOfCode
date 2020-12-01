namespace AdventOfCode.Shared.Contracts
{
    public interface IArgumentDeserializator<TResult>
    {
        TResult Deserialize(string argument);
    }
}
