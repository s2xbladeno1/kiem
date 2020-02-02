using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class DanhGiaSPViewModel
    {
        public int NguoiDungID { get; set; }
        public string HoTen { get; set; }

        public int? MaBL { get; set; }
        public string MaSP { get; set; }
        public string MaMau { get; set; }
        public string MaTT { get; set; }
        public string MaDL { get; set; }
        public string NoiDung { get; set; }
        public double? DanhGia { get; set; }
        public int? ReplyID { get; set; }
        public string ID { get; set; } // ID danh mục sản phẩm

    }
}
