using Bccupass_CoreMVC.Models.DTO;
using System.Collections.Generic;

namespace Bccupass_CoreMVC.Services.Interface
{
    public interface ITicketDetailOrderDetailService
    {
        public IEnumerable<TicketDetailOrderDetailDto> GetGTicketByActivityId(int id);

        public TicketDetailOrderDetailDto GetOrder(int id);

        public void TicketCount(int TicketId);
    }
}
