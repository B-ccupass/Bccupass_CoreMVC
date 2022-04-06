using Bccupass_CoreMVC.Common.Funtion;
using Bccupass_CoreMVC.Models.ViewModel.ActivityCard;
using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.ViewModel.Activity
{
    public class ActivityIndexViewModel
    {
        public IEnumerable<ActivityCardViewModel.ActivityCardData> ActivityList { get; set; }
        public Pagination pageInfo { get; set; }
        public int ActivityStateByTime { get; set; }
        public int ActivitySortOrder { get; set; }
    }
}
