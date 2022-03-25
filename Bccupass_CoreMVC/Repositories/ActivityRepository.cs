using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Repositories.Interface;

namespace Bccupass_CoreMVC.Repositories
{
    public class ActivityRepository : DBRepository, IActivityRepository
    {
        public ActivityRepository(BccupassDBContext context) : base(context)
        {
        }
    }
}
