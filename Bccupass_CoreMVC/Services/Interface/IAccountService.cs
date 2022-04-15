using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bccupass_CoreMVC.Models.DTO.Account;


namespace Bccupass_CoreMVC.Services.Interface
{
    public interface IAccountService
    {
        public CreateAccountOutputDto CreateAccount(CreateAccountInputDto input); //建帳號
        public LoginAccountOutputDto LoginAccount(LoginAccountInputDto input); //登入帳號

        public void LogoutAccount();//登出

        public bool IsExistAccount(string email);//是否已存在(布林)
        public void VerifyAccount(int userId);//已驗證
    }
}
