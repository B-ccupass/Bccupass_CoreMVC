using Bccupass_CoreMVC.Models.DTO.Ticket;
using System.Collections.Generic;

namespace Bccupass_CoreMVC.Services.Interface
{
    public interface ITicketService
    {
        public ShowTicketDto GetTicket(int orderDetailId);

        public int TicketCount(int orderDetailId);
        public IEnumerable<TicketPurchaseDto> GetTicketInfoAtPurchase(int activityId);
        public TicketFormDto GetTicketFormByActivityId(int activityId);
    }
}
