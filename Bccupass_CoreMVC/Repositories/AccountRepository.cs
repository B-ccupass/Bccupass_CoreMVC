using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Repositories.Interface;

namespace Bccupass_CoreMVC.Repositories
{
    public class AccountRepository : DBRepository, IAccountRepository
    {
        public AccountRepository(BccupassDBContext context) : base(context)
        {
        }
    }
}
