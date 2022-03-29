using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.ViewModel
{
    public class CreateTicketViewModel
    {
        public OrderData Order { get; set; }
        public IEnumerable<TicketDetailOrderDetail> TdOd { get; set; }
        public IEnumerable<TicketDatail> TicketDetail { get; set; }
        public ActivityData Activity { get; set; }
        public OrganizerData Organizer { get; set; }


        public class TicketDetailOrderDetail
        {
            public int TdOdId { get; set; }
            public string BuyerName { get; set; }
            public string BuyerEmail { get; set; }
            public string BuyerPhone { get; set; }
            public string BuyerCompanyName { get; set; }
        }



        public class TicketDatail
        {
            public int TicketId { get; set; }
            public string TicketName { get; set; }

        }

        public class ActivityData
        {
            public int ActId { get; set; }
            public string ActName { get; set; }
        }

        public class OrganizerData
        {
            public int OrgId { get; set; }
            public string OrgName { get; set; }
            public string OrgPhone { get; set; }
            public string OrgEmail { get; set; }
        }

        public class OrderData
        {
            public int OrderId { get; set; }
        }
    }
}
