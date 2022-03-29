using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Models.ViewModel.Organizer
{
    public class OrganizerAboutViewModel
    {
        public OrganizerData organizer { get; set; }
        public IEnumerable<ActivityData> ActivityList { get; set; }
        public class OrganizerData
        {
            public int OrganizerId { get; set; }
            public string Banner { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public string Description { get; set; }
            public string OfficialWebsite { get; set; }
            public string FacebookWebsite { get; set; }
            public string InstagramWebsite { get; set; }
            public string YoutubeWebsite { get; set; }
            public string MediumWebsite { get; set; }
        }
        public class ActivityData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string City { get; set; }
            public string ActivityTheme { get; set; }
            public bool IsFree { get; set; }
            public int? Favorite { get; set; }
            public int State { get; set; }
        }
    }
}
