using Bccupass_CoreMVC.Services.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Services
{
    public class MailService : IMailService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MailService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public void SendForgetPasswordEmail(string mailTo)
        {
            //寄信的通訊協定SMTP，查Google的Server是什麼
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential("Bccupass@gmail.com", "Bccupass0330");
            client.EnableSsl = true;

            //Mail
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("Bccupass@gmail.com", "Bccupass");
            mail.To.Add(mailTo);
            mail.Priority = MailPriority.Normal;
            mail.Subject = "Bccupass 重設密碼";
            mail.IsBodyHtml = true;

            mail.Body = @$"<button>設定你的密碼</button> 
                           <a href='https://{_httpContextAccessor.HttpContext.Request.Host.Value}/Account/ResetPassword?email={mailTo}' target='_blank'>連結</a>";
            client.Send(mail);
        }
    }
}
