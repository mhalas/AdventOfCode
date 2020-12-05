namespace AdventOfCode.Shared.Dto
{
    public class BinaryBoardingDto
    {
        

        public BinaryBoardingDto(string binaryValue, int row, int column, int seatId)
        {
            BinaryValue = binaryValue;
            Row = row;
            Column = column;
            SeatId = seatId;
        }

        public string BinaryValue { get; }
        public int Row { get; }
        public int Column { get; }
        public int SeatId { get; }

    }
}
