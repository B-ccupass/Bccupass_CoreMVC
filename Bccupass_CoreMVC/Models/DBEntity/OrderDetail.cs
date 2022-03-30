using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            TicketDetailOrderDetails = new HashSet<TicketDetailOrderDetail>();
        }

        public int OrderDetailId { get; set; }
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderTime { get; set; }
        public int OrderState { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<TicketDetailOrderDetail> TicketDetailOrderDetails { get; set; }
    }
}
