namespace AdventOfCode.Shared.Results
{
    public class HandheldHaltingResult
    {

        public HandheldHaltingResult(int value, bool isCorrupted)
        {
            Value = value;
            IsCorrupted = isCorrupted;
        }

        public int Value { get; }
        public bool IsCorrupted { get; }
    }
}
