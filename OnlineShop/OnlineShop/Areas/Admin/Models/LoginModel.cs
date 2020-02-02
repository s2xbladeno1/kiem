using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập tài khoản")]
        public string TaiKhoan { get; set; }
        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string MatKhau { get; set; }
        public bool RememberMe { get; set; }
    }
}