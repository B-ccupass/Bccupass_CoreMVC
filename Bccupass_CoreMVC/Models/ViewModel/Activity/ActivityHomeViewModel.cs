using Bccupass_CoreMVC.Models.ViewModel.Activity;
using System;
using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.ViewModel.ActivityCard
{
    public class ActivityHomeViewModel
    {
        public IEnumerable<ActivityCardViewModel.ActivityCardData> ActivityList { get; set; }
        public IEnumerable<ActivityCardViewModel.ActivityCardData> ActivityListSec { get; set; }

    }
}
