using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Repositories.Interface;

namespace Bccupass_CoreMVC.Repositories
{
    public class UserRepository : DBRepository, IUserRepository
    {
        public UserRepository(BccupassDBContext context) : base(context)
        {
        }
    }
}
