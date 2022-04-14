using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Repositories.Interface;

namespace Bccupass_CoreMVC.Repositories
{
    public class ActivityDraftRepository : DBRepository, IActivityDraftRepository
    {
        public ActivityDraftRepository(BccupassDBContext context) : base(context)
        {

        }
    }
}
