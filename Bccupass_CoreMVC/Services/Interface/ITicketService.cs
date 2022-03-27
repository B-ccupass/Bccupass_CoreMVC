using Bccupass_CoreMVC.Models.DTO.Ticket;
using System.Collections.Generic;

namespace Bccupass_CoreMVC.Services.Interface
{
    public interface ITicketService 
    {
        public IEnumerable<TicketPurchaseDto> GetTicketInfoAtPurchase(int activityId);
    }
}
