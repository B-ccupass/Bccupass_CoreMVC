using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Services.Interface
{
    public interface IMailService
    {
        public void SendForgetPasswordEmail(string mailTo);//寄忘記密碼信，參數有'寄給哪個Email'和'寄給誰'
    }
}
