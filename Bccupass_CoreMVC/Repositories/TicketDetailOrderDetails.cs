using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Repositories;
using Bccupass_CoreMVC.Repositories.Interface;
using System.Linq;

namespace Bccupass_CoreMVC.Repositories
{
    public class TicketDetailOrderDetails :DBRepository, ITicketDetailOrderDetails
    {
        public TicketDetailOrderDetails(BccupassDBContext context) : base(context)
        {
        }
        public int getTicketCount(int ticketDetailId)
        {
            var target = Context.TicketDetailOrderDetails.Where(x => x.TicketDetailId == ticketDetailId).Count();

            return target;
        }
    }
}
