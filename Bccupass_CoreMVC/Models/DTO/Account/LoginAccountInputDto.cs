using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Models.DTO.Account
{
    public class LoginAccountInputDto
    {
        /// <summary>
        /// 帳號(電子郵件)
        /// </summary>
        [Required(ErrorMessage = "必填欄位")]
        [DataType(DataType.EmailAddress)]
        //[RegularExpression(ErrorMessage = "需為xxxx@gmail.com格式")]
        public string Account { get; set; }


        /// <summary>
        /// 密碼
        /// </summary>
        [Required(ErrorMessage = "必填欄位")]
        public string Password { get; set; }
    }
}
