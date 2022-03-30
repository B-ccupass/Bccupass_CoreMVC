using Bccupass_CoreMVC.Models.ViewModel.ActivityCard;
using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.ViewModel.Activity
{
    public class ActivityIndexViewModel
    {
        public IEnumerable<ActivityCardViewModel.ActivityCardData> ActivityList { get; set; }
    }
}
