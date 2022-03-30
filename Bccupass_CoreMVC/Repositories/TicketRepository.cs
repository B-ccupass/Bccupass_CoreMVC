using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Repositories;
using Bccupass_CoreMVC.Repositories.Interface;
using System.Linq;

namespace Bccupass_CoreMVC.Repositories
{
    public class TicketRepository :DBRepository, ITicketRepository 
    {
        public TicketRepository(BccupassDBContext context) : base(context)
        {
        }
    }
}
