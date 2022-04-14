using System;

namespace Bccupass_CoreMVC.Models.DTO.Ticket
{
    public class TicketPurchaseDto
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
        public int BuyLeastCount { get; set; }
        public int BuyMostCount { get; set; }

        //庫存
    }
}
