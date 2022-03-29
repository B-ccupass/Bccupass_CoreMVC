using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Repositories.Interface;

namespace Bccupass_CoreMVC.Repositories
{
    public class OrganizerRepository : DBRepository, IOrganizerRepository
    {
        public OrganizerRepository(BccupassDBContext context) : base(context)
        {
        }
    }
}
