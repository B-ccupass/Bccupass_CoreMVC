using System;

namespace Bccupass_CoreMVC.Models.DTO.Activity
{
    public class ActivityCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? City { get; set; }
        public int ActivityPrimaryThemeId { get; set; }
    }
}
