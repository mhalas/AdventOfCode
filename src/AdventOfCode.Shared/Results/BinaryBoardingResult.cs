using AdventOfCode.Shared.Dto;

namespace AdventOfCode.Shared.Results
{
    public class BinaryBoardingResult
    {
        public BinaryBoardingResult(BinaryBoardingDto highestBoarding, int mySeatId)
        {
            HighestBoarding = highestBoarding;
            MySeatId = mySeatId;
        }

        public BinaryBoardingDto HighestBoarding { get; set; }
        public int MySeatId { get; set; }
    }
}
