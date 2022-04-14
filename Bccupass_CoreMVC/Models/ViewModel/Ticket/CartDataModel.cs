using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.ViewModel.Ticket
{
    public class CartDataModel
    {
        public bool IsFreeTicket { get; set; }
        public int ActivityId { get; set; }
        public IEnumerable<TicketData> CartList { get; set; }

        public class TicketData
        {
            public int TicketId { get; set; }
            public string TicketName { get; set; }
            public int BuyCount { get; set; }
        }
    }
}
