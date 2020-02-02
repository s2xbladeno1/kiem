using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class DangKyModel
    {
        public int ID { get; set; }
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage ="Vui lòng nhập tên đăng nhập")]
        public string TaiKhoan { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(20, MinimumLength =6,ErrorMessage ="Mật khẩu có ít nhất 6 ký tự")]
        public string MatKhau { get; set; }
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("MatKhau",ErrorMessage ="Xác nhận mật khẩu không đúng!")]
        public string XacNhanMK { get; set; }
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string HoTen { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string SDT { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập email")]
        public string Email { get; set; }
    }
}