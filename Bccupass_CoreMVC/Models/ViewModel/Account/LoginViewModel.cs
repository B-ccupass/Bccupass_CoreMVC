using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Models.ViewModel.Account
{
    public class LoginViewModel
    {
        public OutputData Output { get; set; }
        public InputData Input { get; set; }
        public SignUpResponse Response { get; set; }

        public class OutputData
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string UserEmail { get; set; }
            public string UserImage { get; set; }
        }

        public class InputData
        {
            public string Account { get; set; }
            public string Password { get; set; }
        }
        public class SignUpResponse
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; }

        }
    }
}
