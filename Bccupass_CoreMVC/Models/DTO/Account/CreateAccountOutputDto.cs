using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Models.DTO.Account
{
    public class CreateAccountOutputDto
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }


        /// <summary>
        /// 提示訊息
        /// </summary>
        public string Message { get; set; }



        public UserData User { get; set; } = new UserData();  //傳回註冊好的那些基本資訊

        public class UserData
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
    }
}
