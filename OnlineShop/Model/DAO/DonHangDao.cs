using Model.EF;
using Model.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class DonHangDao
    {
        OnlineShopDbContext db = null;
        public DonHangDao()
        {
            db = new OnlineShopDbContext();
        }
        public int Insert(DonHang donhang)
        {
            db.DonHangs.Add(donhang);
            db.SaveChanges();
            return donhang.MaDH;
        }
        public bool XoaDH(DonHang donhang)
        {
            db.DonHangs.Remove(donhang);
            db.SaveChanges();
            return true;
        }
        public IEnumerable<DonHang> ListDonHang(int page, int pageSize)
        {
            return db.DonHangs.OrderByDescending(x=>x.NgayBan).ToPagedList(page,pageSize);
        }
        public List<DonHang> LichSuDatHang()
        {
            return db.DonHangs.ToList();
        }
        public DonHang oneDonHang(int madh)
        {
            return db.DonHangs.Where(x=>x.MaDH == madh).SingleOrDefault();
        }
        public DonHang CapNhat(int madh, string tt)
        {
            var dh =  db.DonHangs.Where(x => x.MaDH == madh).SingleOrDefault();
            if(dh.MaDH == madh)
            {
                dh.TrangThai = tt;
                db.SaveChanges();
                return dh;
            }
            else
            {
                return dh;
            }
        }
        public IEnumerable<DonHang> ListDHTheoTrangThai(string tt,int page, int pageSize)
        {
            return db.DonHangs.Where(x=>x.TrangThai == tt).OrderByDescending(x => x.NgayBan).ToPagedList(page, pageSize);
        }
        public decimal DoanhThuTheoThang(int Thang, int Nam)
        {
            decimal TongTien=0;
            var listDHtheoThang = db.DonHangs.Where(x => x.NgayBan.Month == Thang && x.NgayBan.Year == Nam && x.TrangThai == "Đã nhận hàng");
            foreach( var item in listDHtheoThang)
            {
                TongTien += item.TongTien??0;
            }
            return TongTien;
        }
    }
}
