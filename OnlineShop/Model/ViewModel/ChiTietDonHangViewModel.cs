using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class ChiTietDonHangViewModel
    {
        public int SoLuong { get; set; }
        public decimal ThanhTien { get; set; }
        public string TenDayDu { get; set; }
        public int MaDH { get; set; }
        public DateTime NgayBan { get; set; }
        public string DMSPID { get; set; }
        public string MaSP { get; set; }
        public string MaDL { get; set; }
        public string MaTT { get; set; }
        public string MaMau { get; set; }
    }
}
