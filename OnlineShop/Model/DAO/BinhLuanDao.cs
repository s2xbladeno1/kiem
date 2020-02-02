using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class BinhLuanDao
    {
        OnlineShopDbContext db = null;
        public BinhLuanDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<DanhGiaSPViewModel> ListDanhGiaSP(string iddmsp, string masp, string mamau, string matt, string madl)
        {
            var danhGiaSP = (from a in db.BinhLuans
                             join b in db.NguoiDungs on a.NguoiDungID equals b.ID
                             join c in db.SanPhams on a.MaSP equals c.MaSP
                             join d in db.DanhMucSanPhams on c.DMSPID equals d.ID
                             where a.DanhGia != null && a.MaSP == masp && a.MaTT == matt && a.MaDL == madl && a.MaMau == mamau
                             select new DanhGiaSPViewModel()
                             {
                                 ID = iddmsp,
                                 MaBL = a.MaBL,
                                 MaSP = a.MaSP,
                                 MaDL = a.MaDL,
                                 MaMau = a.MaMau,
                                 MaTT = a.MaTT,
                                 HoTen = b.HoTen,
                                 NoiDung = a.NoiDung,
                                 DanhGia = a.DanhGia,
                                 ReplyID = a.ReplyID
                             }).ToList();
            return danhGiaSP;
        }
        public bool Insert(DanhGiaSPViewModel dgsp)
        {
            var bl = new BinhLuan();
            bl.NguoiDungID = dgsp.NguoiDungID;
            bl.MaSP = dgsp.MaSP;
            bl.MaDL = dgsp.MaDL;
            bl.MaTT = dgsp.MaTT;
            bl.MaMau = dgsp.MaMau;
            bl.NoiDung = dgsp.NoiDung;
            bl.DanhGia = dgsp.DanhGia;
            bl.ReplyID = dgsp.ReplyID;
            db.BinhLuans.Add(bl);
            db.SaveChanges();
            return true;
        }
        public List<DonHangViewModel> SoLanMuaCua1KH(int iduser, string masp, string mamau, string matt, string madl)
        {
            var list = (from a in db.DonHangs
                        join b in db.ChiTietDonHangs on a.MaDH equals b.MaDH
                        where b.MaDH == a.MaDH && b.MaSP == masp && b.MaTT == matt && b.MaDL == madl && b.MaMau == mamau && a.MaKH == iduser && a.TrangThai == "Đã nhận hàng"
                        select new DonHangViewModel()
                        {
                            MaDH = a.MaDH,
                            MaSP = b.MaSP,
                            MaMau = b.MaMau,
                            MaTT = b.MaTT,
                            MaDL = b.MaDL,
                            MaKH = iduser
                        }).ToList();
            return list;
        }
        public List<BinhLuan> SoLanDanhGia(int iduser, string masp, string mamau, string matt, string madl)
        {
            return db.BinhLuans.Where(x => x.NguoiDungID == iduser && x.MaSP == masp && x.MaMau == mamau && x.MaTT == matt && x.MaDL == madl).ToList();
        }
        public double? DiemDanhGia(string masp, string mamau, string matt, string madl)
        {
            var diemDanhGia = db.BinhLuans.Where(x => x.MaSP == masp && x.MaMau == mamau && x.MaTT == matt && x.MaDL == madl).Select(x => x.DanhGia).ToList();
            if(diemDanhGia.Count == 0)
            {
                return 0;
            }
            else
            {
                double? dtb = diemDanhGia.Average();
                string dtbString = Convert.ToString(dtb);
                if(dtbString.Length == 1)
                {
                    double dtbDoubleRutGon = Convert.ToDouble(dtbString);
                    return dtbDoubleRutGon;
                }
                else
                {
                    string dtbStringRutGon = dtbString.Substring(0, 3);
                    double dtbDoubleRutGon = Convert.ToDouble(dtbStringRutGon);
                    return dtbDoubleRutGon;
                }
            }
        }
        public List<DanhGiaSPViewModel> ReplyDanhGia(string masp, string mamau, string matt, string madl)
        {
            var replyID = (from a in db.BinhLuans
                             join b in db.NguoiDungs on a.NguoiDungID equals b.ID
                             where a.ReplyID != null && a.MaSP == masp && a.MaTT == matt && a.MaDL == madl && a.MaMau == mamau
                             select new DanhGiaSPViewModel()
                             {
                                 MaBL = a.MaBL,
                                 MaSP = a.MaSP,
                                 MaDL = a.MaDL,
                                 MaMau = a.MaMau,
                                 MaTT = a.MaTT,
                                 HoTen = b.HoTen,
                                 NoiDung = a.NoiDung,
                                 DanhGia = a.DanhGia,
                                 ReplyID = a.ReplyID
                             }).ToList();
            return replyID;
        }
        public DanhGiaSPViewModel TenNguoiDanhGia(int? mabl, string masp, string mamau, string matt, string madl)
        {
            var replyID = (from a in db.BinhLuans
                           join b in db.NguoiDungs on a.NguoiDungID equals b.ID
                           where a.MaBL == mabl
                           select new DanhGiaSPViewModel()
                           {
                               MaBL = a.MaBL,
                               MaSP = a.MaSP,
                               MaDL = a.MaDL,
                               MaMau = a.MaMau,
                               MaTT = a.MaTT,
                               HoTen = b.HoTen,
                               NoiDung = a.NoiDung,
                               DanhGia = a.DanhGia,
                           }).SingleOrDefault();
            return replyID;
        }
    }
}
