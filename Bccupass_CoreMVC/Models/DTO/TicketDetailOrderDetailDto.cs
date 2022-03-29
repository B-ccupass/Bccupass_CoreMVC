using Bccupass_CoreMVC.Models.DBEntity;
using System;

namespace Bccupass_CoreMVC.Models.DTO
{
    public class TicketDetailOrderDetailDto
    {
        public int TicketDetailOrderDetailId { get; set; }
        public int OrderDetailId { get; set; }
        public int TicketDetailId { get; set; }
        public string BuyerName { get; set; }
        public string BuyerEmail { get; set; }
        public string BuyerPhone { get; set; }
        public DateTime? BuyerBirthday { get; set; }
        public int? BuyerIndustry { get; set; }
        public int? BuyerDepartment { get; set; }
        public int? BuyerMonthlyIncome { get; set; }
        public string BuyerIdnumber { get; set; }
        public int? BuyerDiningNeeds { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
        public virtual TicketDatail TicketDetail { get; set; }
    }
}
