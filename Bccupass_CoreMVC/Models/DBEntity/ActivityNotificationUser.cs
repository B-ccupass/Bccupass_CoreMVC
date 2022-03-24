using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class ActivityNotificationUser
    {
        public int ActivityNotificationUserId { get; set; }
        public int ActivityNotificationId { get; set; }
        public int UserId { get; set; }

        public virtual ActivityNotification ActivityNotification { get; set; }
        public virtual User User { get; set; }
    }
}
