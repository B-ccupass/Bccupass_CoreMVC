using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class SystemAnnouncement
    {
        public int SystemAnnouncementId { get; set; }
        public DateTime ReleaseTime { get; set; }
        public string SystemAnnouncementTitle { get; set; }
        public string SystemAnnouncementText { get; set; }
    }
}
