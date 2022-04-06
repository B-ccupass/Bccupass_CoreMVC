using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bccupass_CoreMVC.Repositories.Interface;
using Bccupass_CoreMVC.Models.DBEntity;


namespace Bccupass_CoreMVC.Repositories
{
    public class MailRepository :DBRepository, IMailRepository
    {
        public MailRepository(BccupassDBContext context) : base(context)
        {

        }
    }
}
