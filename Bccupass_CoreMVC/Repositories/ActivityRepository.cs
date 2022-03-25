using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Repositorirs.Interface;

namespace Bccupass_CoreMVC.Repositorirs
{
    public class ActivityRepository : DBRepository, IActivityRepository
    {
        public ActivityRepository(BccupassDBContext context) : base(context)
        {
        }
    }
}
