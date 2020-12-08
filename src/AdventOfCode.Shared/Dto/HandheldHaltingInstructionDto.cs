namespace AdventOfCode.Shared.Dto
{
    public class HandheldHaltingInstructionDto
    {
        public HandheldHaltingInstructionDto(string operation, bool isIncrement, int value)
        {
            Operation = operation;
            IsIncrement = isIncrement;
            Value = value;
        }

        public string Operation { get; set; }
        public bool IsIncrement { get; }
        public int Value { get; }
    }
}
