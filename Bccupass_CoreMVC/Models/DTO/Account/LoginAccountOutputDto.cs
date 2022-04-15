using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Models.DTO.Account
{
    public class LoginAccountOutputDto
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }


        /// <summary>
        /// 提示訊息
        /// </summary>
        public string Message { get; set; }



        public UserData User { get; set; } = new UserData();
        public class UserData
        {
            /// <summary>
            /// 使用者Id
            /// </summary>
            public int UserId { get; set; }


            /// <summary>
            /// 姓名
            /// </summary>
            [Required(ErrorMessage ="必填欄位")]
            public string UserName { get; set; }


            /// <summary>
            /// 電子郵件
            /// </summary>
            [Required(ErrorMessage = "必填欄位")]
            [DataType(DataType.EmailAddress)]
            //[RegularExpression(ErrorMessage = "需為xxxx@gmail.com格式")]
            public string UserEmail { get; set; }



            /// <summary>
            /// 使用者頭貼
            /// </summary>
            public string UserImage { get; set; }
        }
    }
}
