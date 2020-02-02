using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class SanPhamViewModel
    {
        public string MaSP { get; set; }
        public string MaMau { get; set; }
        public string MaTT { get; set; }
        public string TenDayDu { get; set; }
        public string TenSP { get; set; }
        public string MauSac { get; set; }
        public decimal Gia { get; set; }
        public string MaLSP { get; set; }
        public string TenLSP { get; set; }
        public string MaDL { get; set; }
        public string BoNho { get; set; }
        public string Anh { get; set; }
        public string Ram { get; set; }
        public string CamChinh { get; set; }
        public string CamPhu { get; set; }
        public string CPU { get; set; }
        public string DoPhanGiai { get; set; }
        public string DLPin { get; set; }
        public string HeDH { get; set; }
        public string KTManHinh { get; set; }
        public string Ten { get; set; }
        public string Url { get; set; }
        public string DaCap { get; set; }
        public string ID { get; set; }
        public string MoTa { get; set; }
        public int SoLuongCon { get; set; }
        public string DMSPID { get; set; }
        public int NguoiDungID { get; set; }
        [Display(Name="Nội Dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Đánh Giá")]
        public string DanhGia { get; set; }
        public int TongSL { get; set; }
    }
}
