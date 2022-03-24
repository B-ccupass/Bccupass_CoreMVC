using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Repositorirs.Interface;

namespace Bccupass_CoreMVC.Repositorirs
{
    public class OrganizerRepository : DBRepository, IOrganizerRepository
    {
        public OrganizerRepository(BccupassDBContext context) : base(context)
        {
        }
    }
}
