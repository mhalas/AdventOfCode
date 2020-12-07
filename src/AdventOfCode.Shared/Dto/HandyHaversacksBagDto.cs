using System.Collections.Generic;

namespace AdventOfCode.Shared.Dto
{
    public class HandyHaversacksBagDto
    {
        public HandyHaversacksBagDto(string bagColor)
        {
            BagColor = bagColor;

            Children = new List<HandyHaversacksBagDto>();
        }

        public HandyHaversacksBagDto(string bagColor, int numberOfBags)
        {
            BagColor = bagColor;
            NumberOfBags = numberOfBags;

            Children = new List<HandyHaversacksBagDto>();
        }

        public string BagColor { get; }

        public int? NumberOfBags { get; }

        public List<HandyHaversacksBagDto> Children { get; }
    }
}
