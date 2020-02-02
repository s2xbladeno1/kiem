using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ChiTietDonHangDao
    {
        OnlineShopDbContext db = null;
        public ChiTietDonHangDao()
        {
            db = new OnlineShopDbContext();
        }
        public bool Insert(ChiTietDonHang cthd)
        {
            try
            {
                db.ChiTietDonHangs.Add(cthd);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<ChiTietDonHangViewModel> ChiTietDonHang(int madh)
        {
            var listctdh=(from a in db.ChiTietDonHangs
                          join b in db.MauSanPhams on new { a.MaSP, a.MaDL, a.MaTT, a.MaMau }  equals new { b.MaSP, b.MaDL, b.MaTT, b.MaMau }
                          join c in db.DonHangs on a.MaDH equals c.MaDH
                          join d in db.SanPhams on b.MaSP equals d.MaSP
                          where a.MaSP == b.MaSP && a.MaDL == b.MaDL && a.MaTT == b.MaTT && a.MaMau == b.MaMau && a.MaDH == c.MaDH
                          select new ChiTietDonHangViewModel(){
                              DMSPID = d.DMSPID,
                              MaSP = b.MaSP,
                              MaMau = b.MaMau,
                              MaTT = b.MaTT,
                              MaDL = b.MaDL,
                              MaDH = a.MaDH,
                              NgayBan = c.NgayBan,
                              TenDayDu = b.TenDayDu,
                              SoLuong = a.SoLuong,
                              ThanhTien = a.ThanhTien
                          }).Where(x => x.MaDH == madh).OrderByDescending(x=>x.NgayBan).ToList();
            return listctdh;
        }
    }
}
