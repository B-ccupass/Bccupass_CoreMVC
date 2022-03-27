﻿using System;

namespace Bccupass_CoreMVC.Models.ViewModel.Ticket
{
    public class TicketPurchaseViewModel
    {
        public int TicketId { get; set; }
        public string TicketName { get; set; }
        public decimal Price { get; set; }
        public DateTime SellStartTime { get; set; }
        public DateTime SellEndTime { get; set; }
        public DateTime CheckStartTime { get; set; }
        public DateTime CheckEndTime { get; set; }
        public string GroupName { get; set; }
    }
}
