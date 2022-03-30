using Bccupass_CoreMVC.Models.DTO;
using System.Collections.Generic;

namespace Bccupass_CoreMVC.Services.Interface
{
    public interface ITicketService
    {
        public CreateTicketDto GetTicket(int orderDetailId);

        public int TicketCount(int orderDetailId);
    }
}
