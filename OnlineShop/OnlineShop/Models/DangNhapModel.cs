using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class DangNhapModel
    {
        [Key]
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage ="Tên đăng nhập không được để trống")]
        public string TaiKhoan { get; set; }


        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string MatKhau { get; set; }
    }
}