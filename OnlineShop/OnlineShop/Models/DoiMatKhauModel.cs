using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class DoiMatKhauModel
    {
        public int ID { get; set; }
        [Display(Name = "Mật khẩu cũ")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu cũ")]
        public string MatKhauCu { get; set; }
        [Display(Name = "Mật khẩu mới")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Mật khẩu có ít nhất 6 ký tự")]
        public string MatKhau { get; set; }
        [Display(Name = "Nhập lại mật khẩu mới")]
        [Compare("MatKhau", ErrorMessage = "Xác nhận mật khẩu không đúng!")]
        public string XacNhanMKMoi { get; set; }
    }
}