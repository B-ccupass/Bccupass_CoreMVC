using System;
using System.Collections.Generic;

#nullable disable

namespace Bccupass_CoreMVC.Models.DBEntity
{
    public partial class TicketDetailOrderDetail
    {
        public int TicketDetailOrderDetailId { get; set; }
        public int OrderDetailId { get; set; }
        public int TicketDetailId { get; set; }
        public bool CheckStatus { get; set; }
        public decimal UniPrice { get; set; }
        public string BuyerName { get; set; }
        public string BuyerEmail { get; set; }
        public string BuyerPhone { get; set; }
        public DateTime? BuyerBirthday { get; set; }
        public string BuyerAddress { get; set; }
        public int? BuyerGender { get; set; }
        public int? BuyerAge { get; set; }
        public string BuyerHobby { get; set; }
        public int? BuyerMaritalStatus { get; set; }
        public int? BuyerIndustry { get; set; }
        public int? BuyerDepartment { get; set; }
        public int? BuyerMonthlyIncome { get; set; }
        public string BuyerIdnumber { get; set; }
        public string BuyerFax { get; set; }
        public int? BuyerEducationLevel { get; set; }
        public int? BuyerDiningNeeds { get; set; }
        public string BuyerCompanyName { get; set; }
        public string BuyerJobTitle { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
        public virtual TicketDatail TicketDetail { get; set; }
    }
}
