using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Models.DTO.Account
{
    public class LoginAccountOutputDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public UserData User { get; set; }
        public class UserData
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string UserPhone { get; set; }
            public string UserEmail { get; set; }
        }
    }
}
