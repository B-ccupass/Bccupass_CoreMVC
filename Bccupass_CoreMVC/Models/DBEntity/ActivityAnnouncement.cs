using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class ActivityAnnouncement
    {
        public int AnnouncementId { get; set; }
        public int ActivityId { get; set; }
        public int Sort { get; set; }
        public string AnnouncementContent { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual Activity Activity { get; set; }
    }
}
