using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class NhapHangDao
    {
        OnlineShopDbContext db = null;
        public NhapHangDao()
        {
            db = new OnlineShopDbContext();
        }
        public bool Insert(NhapHang nhapHang)
        {
            decimal tt = 0;
            var nh = new NhapHang();
            nh.NgayNhap = DateTime.Now;
            nh.MaNH = nhapHang.MaNH;
            nh.TongTien = tt;
            nh.NguoiNhap = nhapHang.NguoiNhap;
            db.NhapHangs.Add(nh);
            db.SaveChanges();
            return true;
        }
        public List<NhapHang> ListNH()
        {
            return db.NhapHangs.ToList();
        }
        public NhapHang oneNH(int manh)
        {
            return db.NhapHangs.Where(x => x.MaNH == manh).SingleOrDefault();
        }
        public ChitietNhapHang SanPham(int manh,string masp, string mamau, string matt, string madl)
        {
            return db.ChitietNhapHangs.Where(x =>x.MaNH == manh && x.MaSP == masp && x.MaMau == mamau && x.MaTT == matt && x.MaDL == madl).SingleOrDefault();
        }
        public bool EditChiTietNhapHang(ChitietNhapHang ctnh)
        {
            var model = db.ChitietNhapHangs.Where(x=>x.MaNH == ctnh.MaNH && x.MaSP == ctnh.MaSP && x.MaMau == ctnh.MaMau && x.MaTT ==  ctnh.MaTT && x.MaDL == ctnh.MaDL).SingleOrDefault();
            model.SoLuongNhap = ctnh.SoLuongNhap;
            model.GiaNhap = ctnh.GiaNhap;
            db.SaveChanges();
            return true;
        }
        public bool XoaItem(int manh, string masp, string mamau, string matt, string madl)
        {
            var item = db.ChitietNhapHangs.Where(x => x.MaNH == manh && x.MaSP == masp && x.MaMau == mamau && x.MaTT == matt && x.MaDL == madl).SingleOrDefault();
            db.ChitietNhapHangs.Remove(item);
            db.SaveChanges();
            return true;
        }
        public decimal TongNhap(int Thang, int Nam)
        {
            var listTongTien = db.NhapHangs.Where(x=>x.NgayNhap.Month == Thang && x.NgayNhap.Year == Nam).Select(x => x.TongTien).ToList();
            return listTongTien.Sum()??0;
        }
    }
}
