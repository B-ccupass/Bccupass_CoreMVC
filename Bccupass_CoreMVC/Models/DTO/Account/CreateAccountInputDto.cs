using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Models.DTO.Account
{
    public class CreateAccountInputDto
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
}
