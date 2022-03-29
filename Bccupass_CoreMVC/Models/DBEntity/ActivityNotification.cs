using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class ActivityNotification
    {
        public ActivityNotification()
        {
            ActivityNotificationUsers = new HashSet<ActivityNotificationUser>();
        }

        public int ActivityNotificationId { get; set; }
        public int ActivityId { get; set; }
        public int ActiveNotificationStatus { get; set; }
        public string LettersSubject { get; set; }
        public string EmailAddress { get; set; }
        public DateTime BuildTime { get; set; }
        public DateTime SendTime { get; set; }
        public string EmailContent { get; set; }

        public virtual ICollection<ActivityNotificationUser> ActivityNotificationUsers { get; set; }
    }
}
