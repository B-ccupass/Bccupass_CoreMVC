using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bccupass_CoreMVC.Services.Interface;
using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Models.DTO.Account;
using Bccupass_CoreMVC.Repositories.Interface;


namespace Bccupass_CoreMVC.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService (IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public CreateAccountOutputDto CreateAccount(CreateAccountInputDto input)
        {
            throw new NotImplementedException();
        }

        public bool IsExistAccount(string email)
        {
            throw new NotImplementedException();
        }

        public LoginAccountOutputDto LoginAccount(LoginAccountInputDto input)
        {
            throw new NotImplementedException();
        }

        public void LogoutAccount()
        {
            throw new NotImplementedException();
        }

        public void VerifyAccount(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
