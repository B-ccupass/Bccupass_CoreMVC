using System;

namespace Bccupass_CoreMVC.Models.ViewModel.CreateActivity
{
    public class CreateTicketViewModel
    {
        public int ActivityDraftId { get; set; }
        public string TicketName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } //票卷說明
        public DateTime SellStartTime { get; set; }
        public DateTime SellEndTime { get; set; }
        public DateTime CheckStartTime { get; set; }
        public DateTime CheckEndTime { get; set; }
        public bool IsSell { get; set; }
        public bool IsCheckEqualActivityTime { get; set; } //有效時間建議設定為活動時間
        public int BuyLimitLeast { get; set; }
        public int BuyLimitMost { get; set; }
    }
}
