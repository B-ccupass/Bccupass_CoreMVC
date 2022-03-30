using System;

namespace Bccupass_CoreMVC.Models.DTO.Activity
{
    public class ActivityBuyTicketDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
    }
}
