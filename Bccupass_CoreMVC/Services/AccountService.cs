using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bccupass_CoreMVC.Services.Interface;
using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Models.DTO.Account;
using Bccupass_CoreMVC.Repositories.Interface;
using Bccupass_CoreMVC.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Bccupass_CoreMVC.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IDBRepository _dbRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AccountService (IAccountRepository accountRepository,IDBRepository dbRepository, IHttpContextAccessor httpContextAccessor)
        {
            _accountRepository = accountRepository;
            _dbRepository = dbRepository;

            _httpContextAccessor = httpContextAccessor;
        }

        public CreateAccountOutputDto CreateAccount(CreateAccountInputDto input)
        {
            var res = new CreateAccountOutputDto();
            res.IsSuccess = false;
            res.User.UserName = input.Name;
            res.User.UserEmail = input.Email;
            res.User.UserPhone = input.Phone;

            //檢核
            if (this.IsExistAccount(input.Email))
            {
                res.Message = "Email已經存在!";
                return res;
            }


            //mapping,預設值驗證前會是false
            //建起來的密碼要是加密的
            var entity = new User
            {
                Email = input.Email,
                Name = input.Name,
                Phone = input.Phone,
                //Password = Encryption.SHA256Encrypt(input.Password),
                Password = input.Password,
                IsAdmin = false,
                Verification = false,
            };

            var target = _dbRepository.Context.Users.Add(entity);
            _dbRepository.Save();

            res.IsSuccess = true;
            res.User.UserId = target.Entity.UserId;


            return res;
        }

        public bool IsExistAccount(string email)
        {
            return _dbRepository.GetAll<User>().Any(x => x.Email == email);
        }

        public LoginAccountOutputDto LoginAccount(LoginAccountInputDto input)
        {
            var res = new LoginAccountOutputDto();
            var currentUser = _dbRepository.GetAll<User>().First(x => x.Email == input.Account);

            //預設是false
            res.IsSuccess = false;

            //檢核
            if (!this.IsExistAccount(input.Account))
            {
                res.Message = "使用者不存在，請先註冊";
                return res;
            }

            if(input.Password != currentUser.Password)
            {
                res.Message = "密碼錯誤";
                return res;
            }

            //結果
            res.IsSuccess = true;
            res.User.UserId = currentUser.UserId;
            res.User.UserName = currentUser.Name;
            res.User.UserEmail = currentUser.Email;
            res.User.UserImage = currentUser.Photo;

            if (res.IsSuccess)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,res.User.UserId.ToString()),
                    new Claim(ClaimTypes.Email,res.User.UserEmail),
                    new Claim("UserName", res.User.UserName),
                    new Claim("UserImage",!string.IsNullOrEmpty(res.User.UserImage) ? res.User.UserImage : "")
                };


                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //請httpContext做登入，然後帶入
                _httpContextAccessor.HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
            }

            return res;
        }

        public void LogoutAccount()
        {
            _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public void VerifyAccount(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
