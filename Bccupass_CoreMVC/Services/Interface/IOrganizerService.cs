using Bccupass_CoreMVC.Models.DTO.Organizer;

namespace Bccupass_CoreMVC.Services.Interface
{
    public interface IOrganizerService
    {
        public OrganizerAboutDto GetOrganizer(int id);
        public GetOrganizerByActivityIdDto GetOrganizerByActivityId(int id);
        public void CreateOrganizer(CreateOrganizerDto request);

    }
}
