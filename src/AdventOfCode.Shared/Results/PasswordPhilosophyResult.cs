namespace AdventOfCode.Shared.Results
{
    public class PasswordPhilosophyResult
    {

        public PasswordPhilosophyResult(int charactersCount, int charactersPositionCount)
        {
            CharactersCount = charactersCount;
            CharactersPositionCount = charactersPositionCount;
        }

        public int CharactersCount { get; }
        public int CharactersPositionCount { get; }
    }
}
