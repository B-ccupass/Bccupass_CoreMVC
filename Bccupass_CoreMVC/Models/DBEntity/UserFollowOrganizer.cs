using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class UserFollowOrganizer
    {
        public int UserFollowOrganizerId { get; set; }
        public int UserId { get; set; }
        public int OrganizerId { get; set; }
        public DateTime BuildTime { get; set; }

        public virtual Organizer Organizer { get; set; }
        public virtual User User { get; set; }
    }
}
