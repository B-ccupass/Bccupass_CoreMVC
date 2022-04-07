using Bccupass_CoreMVC.Models.DTO.Account;
using Bccupass_CoreMVC.Models.ViewModel.Account;
using Bccupass_CoreMVC.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup([FromBody] SignupViewModel req)
        {
            var inputDto = new CreateAccountInputDto
            {
                Email = req.Input.Email,
                Name = req.Input.Name,
                Phone = req.Input.Phone,
                Password = req.Input.Password
            };

            var outputDto = _accountService.CreateAccount(inputDto);

            var signupVM = new SignupViewModel()
            {
                Output = new SignupViewModel.OutputData()
                {
                    UserEmail = outputDto.User.UserEmail,
                    UserName = outputDto.User.UserName,
                    UserId = outputDto.User.UserId,
                    UserPhone = outputDto.User.UserPhone
                }
            };

            if (outputDto.IsSuccess)
            {
                return new JsonResult(new SignupViewModel.SignUpResponse() { IsSuccess = true, Message = "註冊成功" });
            }
            return new JsonResult(new SignupViewModel.SignUpResponse() { IsSuccess = false, Message = "請重新註冊" });
        }


        public IActionResult UserLogin()
        {
            return PartialView("_UserLoginPartial");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginViewModel req)
        {
            var inputDto = new LoginAccountInputDto
            {
                Account = req.Input.Account,
                Password = req.Input.Password
            };

            var outputDto = _accountService.LoginAccount(inputDto);

            if (outputDto.IsSuccess)
            {
                var loginVM = new LoginViewModel()
                {
                    Output = new LoginViewModel.OutputData()
                    {
                        UserId = outputDto.User.UserId,
                        UserEmail = outputDto.User.UserEmail,
                        UserName = outputDto.User.UserName,
                        UserImage = outputDto.User.UserImage
                    },
                    Response = new LoginViewModel.SignUpResponse()
                    {
                        IsSuccess = true,
                        Message = "Success"
                    }
                };
                return new JsonResult(loginVM);
            }
            else
            {
                return new JsonResult(new LoginViewModel()
                {
                    Response = new LoginViewModel.SignUpResponse() { IsSuccess = false, Message = "請重新登入" }
                });
            }

        }

        public IActionResult Logout()
        {
            _accountService.LogoutAccount();
            return Redirect("/");
        }
    }
}
