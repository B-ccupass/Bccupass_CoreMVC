using Bccupass_CoreMVC.Models.DTO.Account;
using Bccupass_CoreMVC.Models.ViewModel.Account;
using Bccupass_CoreMVC.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMailService _mailService;
        public AccountController(IAccountService accountService, IMailService mailService)
        {
            _accountService = accountService;
            _mailService = mailService;
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
            return new JsonResult(new SignupViewModel.SignUpResponse() { IsSuccess = false, Message = outputDto.Message });
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
                        Message = "登入成功"
                    }
                };
                return new JsonResult(loginVM);
            }
            else
            {
                return new JsonResult(new LoginViewModel()
                {
                    Response = new LoginViewModel.SignUpResponse() { IsSuccess = false, Message = outputDto.Message }
                });
            }
        }

        public IActionResult Logout()
        {
            _accountService.LogoutAccount();
            return Redirect("/");
        }

        
        //可收到郵件，連結點不下去，html格式待改
        public IActionResult SendForgetPasswordEmail(string mailTo)
        {
            _mailService.SendForgetPasswordEmail(mailTo);
            return new JsonResult(new { isSuccess = true });
        }

        public IActionResult ResetPassword(string email)
        {
            return View();
        }

        //儲存JS未完成
        [HttpPost]
        public IActionResult RestPassword([FromBody] dynamic viewModel)
        {
            throw new NotImplementedException();
        }



        //關注
        [HttpGet]
        public IActionResult LikeFor(string likeUserId)
        {
            var claims = HttpContext.User.Claims;
            var userId = claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;


            if (userId == null)
            {
                return new JsonResult(new { isSuccess = false, message = "請先登入" });
            }
            return new JsonResult(new { isSuccess = true });
        }
    }
}
