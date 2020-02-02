using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class SPBanRaViewModel
    {
        public string MaSP { get; set; }
        public string MaMau { get; set; }
        public string MaTT { get; set; }
        public string MaDL { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public int? Thang { get; set; }
        public int Nam { get; set; }
    }
}
