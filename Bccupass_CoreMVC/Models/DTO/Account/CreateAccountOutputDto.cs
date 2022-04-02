using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Models.DTO.Account
{
    public class CreateAccountOutputDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public UserData User { get; set; } = new UserData();  //傳回註冊好的那些基本資訊

        public class UserData
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string UserPhone { get; set; }
            public string UserEmail { get; set; }
        }
    }
}
