using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Models.DTO.Organizer;
using Bccupass_CoreMVC.Repositorirs.Interface;
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


        OrganizerAboutDto IOrganizerService.GetOrganizer(int id)
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
    }
}
