using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class Organizer
    {
        public Organizer()
        {
            Activities = new HashSet<Activity>();
            UserFollowOrganizers = new HashSet<UserFollowOrganizer>();
        }

        public int OrganizerId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Banner { get; set; }
        public string Description { get; set; }
        public string Telphone { get; set; }
        public string Email { get; set; }
        public string OfficialWebsite { get; set; }
        public string FacebookWebsite { get; set; }
        public string InstagramWebsite { get; set; }
        public string YoutubeWebsite { get; set; }
        public string MediumWebsite { get; set; }
        public string OrganizerWebQuery { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<UserFollowOrganizer> UserFollowOrganizers { get; set; }
    }
}
