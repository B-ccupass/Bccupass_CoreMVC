using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class TicketDatail
    {
        public TicketDatail()
        {
            TicketDetailOrderDetails = new HashSet<TicketDetailOrderDetail>();
        }

        public int TicketDatailId { get; set; }
        public int ActivityId { get; set; }
        public string TicketName { get; set; }
        public string TicketGroup { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime SellStartTime { get; set; }
        public DateTime SellEndTime { get; set; }
        public DateTime CheckStartTime { get; set; }
        public DateTime CheckEndTime { get; set; }
        public bool IsSell { get; set; }
        public int BuyLimitLeast { get; set; }
        public int BuyLimitMost { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual ICollection<TicketDetailOrderDetail> TicketDetailOrderDetails { get; set; }
    }
}
