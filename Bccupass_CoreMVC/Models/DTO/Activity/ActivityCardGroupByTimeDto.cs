using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.DTO.Activity
{
    public class ActivityCardGroupByTimeDto
    {
        public IEnumerable<ActivityCardDto> NotStart { get; set; }
        public IEnumerable<ActivityCardDto> End { get; set; }
        public IEnumerable<ActivityCardDto> InProgress { get; set; }
    }
}
