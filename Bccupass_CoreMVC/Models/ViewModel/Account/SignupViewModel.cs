using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Models.ViewModel.Account
{
    public class SignupViewModel
    {
        public OutputData Output { get; set; }
        public InputData Input { get; set; }
        public SignUpResponse Response { get; set; }

        public class OutputData
        {
            /// <summary>
            /// 使用者Id
            /// </summary>
            public int UserId { get; set; }


            /// <summary>
            /// 姓名
            /// </summary>
            [Required(ErrorMessage = "必填欄位")]
            public string UserName { get; set; }


            /// <summary>
            /// 電話
            /// </summary>
            [Required(ErrorMessage = "必填欄位")]
            [RegularExpression(@"^09\d{2}-\d{6}", ErrorMessage = "需為09xx-xxxxxx格式")]
            public string UserPhone { get; set; }


            /// <summary>
            /// 電子郵件
            /// </summary>
            [Required(ErrorMessage = "必填欄位")]
            [DataType(DataType.EmailAddress)]
            //[RegularExpression(ErrorMessage = "需為xxxx@gmail.com格式")]
            public string UserEmail { get; set; }
        }
        
        public class InputData
        {
            /// <summary>
            /// 電子郵件
            /// </summary>
            [Required(ErrorMessage = "必填欄位")]
            [DataType(DataType.EmailAddress)]
            //[RegularExpression(ErrorMessage = "需為xxxx@gmail.com格式")]
            public string Email { get; set; }

            /// <summary>
            /// 姓名
            /// </summary>
            [Required(ErrorMessage = "必填欄位")]
            public string Name { get; set; }

            /// <summary>
            /// 電話
            /// </summary>
            [Required(ErrorMessage = "必填欄位")]
            [RegularExpression(@"^09\d{2}-\d{6}", ErrorMessage = "需為09xx-xxxxxx格式")]
            public string Phone { get; set; }


            /// <summary>
            /// 密碼
            /// </summary>
            [Required(ErrorMessage = "必填欄位")]
            public string Password { get; set; }
        }


        public class SignUpResponse
        {
            /// <summary>
            /// 是否成功
            /// </summary>
            public bool IsSuccess { get; set; }

            /// <summary>
            /// 提示訊息
            /// </summary>
            public string Message { get; set; }
        }


    }
}
