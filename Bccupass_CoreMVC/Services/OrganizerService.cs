using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Models.DTO.Organizer;
using Bccupass_CoreMVC.Repositories.Interface;
using Bccupass_CoreMVC.Services.Interface;
using System.Linq;


namespace Bccupass_CoreMVC.Services
{
    public class OrganizerService : IOrganizerService
    {

        private readonly IOrganizerRepository _context;

        public OrganizerService(IOrganizerRepository context)
        {
            _context = context;
        }

        public OrganizerAboutDto GetOrganizer(int id)
        {
            var org = _context.GetAll<Organizer>().First(x => x.OrganizerId == id);
            return new OrganizerAboutDto()
            {
                OrganizerId = org.OrganizerId,
                Name = org.Name,
                Banner = org.Banner,
                Email = org.Email,
                Image = org.Image,
                Description = org.Description,
                OfficialWebsite = org.OfficialWebsite,
                FacebookWebsite = org.FacebookWebsite,
                InstagramWebsite = org.InstagramWebsite,
                MediumWebsite = org.MediumWebsite,
                YoutubeWebsite = org.YoutubeWebsite
            };
        }

        public GetOrganizerByActivityIdDto GetOrganizerByActivityId(int id)
        {
            var joinResult = (from x in _context.GetAll<Activity>()
                              join y in _context.GetAll<Organizer>() on x.OrganizerId equals y.OrganizerId
                              where x.ActivityId == id
                              select y).FirstOrDefault();
            return new GetOrganizerByActivityIdDto()
            {
                OrganizerId = joinResult.OrganizerId,
                Name = joinResult.Name,
                Email = joinResult.Email,
                Description = joinResult.Description,
                Image = joinResult.Image,
            };
        }
    }
}
