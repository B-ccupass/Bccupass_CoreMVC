using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bccupass_CoreMVC.Models.ViewModel.CreateActivity
{
    public class CreateTicketViewModel
    {
        public int ActivityDraftId { get; set; }
        public string TicketName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Description { get; set; } //票卷說明
        public string SellStartTime { get; set; }
        public string SellStartHour { get; set; }
        public string SellStartMin { get; set; }
        public string SellEndTime { get; set; }
        public string SellEndHour { get; set; }
        public string SellEndMin { get; set; }
        public string CheckStartTime { get; set; }
        public string CheckStartHour { get; set; }
        public string CheckStartMin { get; set; }
        public string CheckEndTime { get; set; }
        public string CheckEndHour { get; set; }
        public string CheckEndMin { get; set; }
        public bool IsSell { get; set; }
        public bool IsCheckEqualActivityTime { get; set; } //有效時間建議設定為活動時間
        public bool IsFree { get; set; }//是否免費
        public int BuyLimitLeast { get; set; }
        public int BuyLimitMost { get; set; }
        public string TicketGroup { get; set; }
        public int Sort { get; set; } 
    }
}
