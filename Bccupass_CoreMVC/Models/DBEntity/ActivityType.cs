using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class ActivityType
    {
        public ActivityType()
        {
            Activities = new HashSet<Activity>();
        }

        public int ActivityTypeId { get; set; }
        public string TypeName { get; set; }
        public string TypeImg { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}
