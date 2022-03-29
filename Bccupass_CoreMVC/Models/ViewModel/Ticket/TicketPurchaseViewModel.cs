using System;
using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.ViewModel.Ticket
{
    public class TicketPurchaseViewModel
    {
        public ActivityData ActivityList { get; set; }
        public IEnumerable<TicketData> TicketList { get; set; }


        public class ActivityData
        {
            public int ActivityId { get; set; }
            public string ActivityName { get; set; }
            public string Image { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string City { get; set; }
            public string District { get; set; }
            public string Address { get; set; }
        }
        public class TicketData
        {
            public int TicketId { get; set; }
            public string TicketName { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public string Description { get; set; }
            public DateTime SellStartTime { get; set; }
            public DateTime SellEndTime { get; set; }
            public DateTime CheckStartTime { get; set; }
            public DateTime CheckEndTime { get; set; }
            public string GroupName { get; set; }
        }

        
    }
}
