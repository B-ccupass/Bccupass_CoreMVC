using System;
using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.ViewModel.ActivityCard
{
    public class ActivityCardViewModel
    {
        public IEnumerable<ActivityData> ActivityList { get; set; }
        public class ActivityData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string City { get; set; }
            public string ActivityTheme { get; set; }
            public string IsFree { get; set; }
            public int? Favorite { get; set; }
        }
    }
}
