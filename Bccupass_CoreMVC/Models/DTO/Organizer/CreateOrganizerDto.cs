namespace Bccupass_CoreMVC.Models.DTO.Organizer
{
    public class CreateOrganizerDto
    {
        public int OrganizerId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Telphone { get; set; }
    }
}
