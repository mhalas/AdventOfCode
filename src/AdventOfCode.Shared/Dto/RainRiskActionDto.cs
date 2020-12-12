namespace AdventOfCode.Shared.Dto
{
    public class RainRiskActionDto
    {
        public RainRiskActionDto(string action, int value)
        {
            Action = action;
            Value = value;
        }

        public string Action { get; }
        public int Value { get; }
    }
}
