using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Models.DTO.Organizer
{
    public class GetOrganizerByActivityIdDto
    {
        public int OrganizerId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }

    }
}
