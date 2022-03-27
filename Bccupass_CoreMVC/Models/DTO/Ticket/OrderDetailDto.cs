using System;

namespace Bccupass_CoreMVC.Models.DTO.Ticket
{
    public class OrderDetailDto
    {
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderTime { get; set; }
        public int OrderState { get; set; }
    }
}
