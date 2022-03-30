using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class ActivityAnnouncement
    {
        public int ActivityAnnouncementId { get; set; }
        public int ActivityId { get; set; }
        public int AnnouncementOrder { get; set; }
        public string ActivityAnnouncementText { get; set; }
        public DateTime ReleaseTime { get; set; }

        public virtual Activity Activity { get; set; }
    }
}
