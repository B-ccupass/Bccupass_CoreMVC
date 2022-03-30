namespace Bccupass_CoreMVC.Models.DTO.Ticket
{
    public class TicketOrderDto
    {
        public int OrderDetailId { get; set; }
        public int TicketDtailId { get; set; }
        public bool CheckStatus { get; set; }
        public decimal Price { get; set; }
        public string BuyerName { get; set; }
        public string BuyerEmail { get; set; }
        public string BuyerPhone { get; set; }
    }
}
