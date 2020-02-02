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
    public class SanPhamDao
    {
        OnlineShopDbContext db = new OnlineShopDbContext();
        public IEnumerable<SanPham> SanPham(int page, int pageSize)
        {
            return db.SanPhams.OrderByDescending(x => x.MaSP).ToPagedList(page,pageSize);
        }
        public List<SanPhamViewModel> ListAll()
        {
            var sanpham = (from a in db.SanPhams
                           join b in db.MauSanPhams on a.MaSP equals b.MaSP
                           join c in db.MauSacs on b.MaMau equals c.MaMau
                           join d in db.TinhTrangMays on b.MaTT equals d.MaTT
                           join e in db.DungLuongs on b.MaDL equals e.MaDL
                           join f in db.DanhMucSanPhams on a.DMSPID equals f.ID
                           join g in db.LoaiSanPhams on a.MaLSP equals g.MaLSP
                           select new SanPhamViewModel()
                           {
                               MaLSP = a.MaLSP,
                               MaSP = b.MaSP,
                               MaTT = b.MaTT,
                               TenDayDu = b.TenDayDu,
                               MaMau = b.MaMau,
                               Gia = b.Gia,
                               Anh = b.Anh,
                               MauSac = c.MauSac1,
                               MaDL = b.MaDL,
                               BoNho = e.BoNho,
                               Ram = a.Ram,
                               CamChinh = a.CamChinh,
                               CamPhu = a.CamPhu,
                               CPU = a.CPU,
                               DoPhanGiai = a.DoPhanGiai,
                               DLPin = a.DLPin,
                               HeDH = a.HeDH,
                               KTManHinh = a.KTManHinh,
                               ID = f.ID,
                               Ten = f.Ten,
                               TenLSP = g.TenLSP,
                               MoTa = d.MoTa,
                               SoLuongCon = b.SoLuongCon,
                               TenSP = a.TenSP,
                               DMSPID = a.DMSPID
                           }).OrderByDescending(x => x.DMSPID).ToList();
            return sanpham;
        }
        public MauSanPham ViewDetail(string masp, string mamau, string matt, string madl)
        {
            var sp = db.MauSanPhams.Find(masp, mamau, matt, madl);
            return sp;
        }
        public List<string> ListName(string keyword)
        {
            return db.MauSanPhams.Where(x => x.TenDayDu.Contains(keyword)).Select(x => x.TenDayDu).ToList();
        }
        public List<SanPhamViewModel> Search(string keyword)
        {
            var sanpham = (from a in db.SanPhams
                           join b in db.MauSanPhams on a.MaSP equals b.MaSP
                           join c in db.MauSacs on b.MaMau equals c.MaMau
                           join d in db.TinhTrangMays on b.MaTT equals d.MaTT
                           join e in db.DungLuongs on b.MaDL equals e.MaDL
                           where b.TenDayDu.Contains(keyword)
                           select new SanPhamViewModel()
                           {
                               MaLSP = a.MaLSP,
                               DMSPID = a.DMSPID,
                               MaSP = b.MaSP,
                               MaTT = b.MaTT,
                               TenDayDu = b.TenDayDu,
                               MaMau = b.MaMau,
                               Gia = b.Gia,
                               Anh = b.Anh,
                               MauSac = c.MauSac1,
                               MaDL = b.MaDL,
                               BoNho = e.BoNho,
                               Ram = a.Ram,
                               CamChinh = a.CamChinh,
                               CamPhu = a.CamPhu,
                               CPU = a.CPU,
                               DoPhanGiai = a.DoPhanGiai,
                               DLPin = a.DLPin,
                               HeDH = a.HeDH,
                               KTManHinh = a.KTManHinh
                           }).ToList();
            return sanpham;
        }
        public IEnumerable<DanhMucSanPham> ListDMSP(int page, int pageSize)
        {
            return db.DanhMucSanPhams.OrderByDescending(x=>x.DaCap).ToPagedList(page,pageSize);
        }
        public List<DanhMucSanPham> MenuCha()
        {
            return db.DanhMucSanPhams.OrderByDescending(x=>x.MaLSP).ToList();
        }

        public List<SanPhamViewModel> ListSPtheoDMSPCon(string iddmsp)
        {
            var sanpham = (from a in db.SanPhams
                           join b in db.MauSanPhams on a.MaSP equals b.MaSP
                           join c in db.MauSacs on b.MaMau equals c.MaMau
                           join d in db.TinhTrangMays on b.MaTT equals d.MaTT
                           join e in db.DungLuongs on b.MaDL equals e.MaDL
                           join f in db.DanhMucSanPhams on a.DMSPID equals f.ID
                           where a.DMSPID == iddmsp
                           select new SanPhamViewModel()
                           {
                               MaSP = b.MaSP,
                               MaTT = b.MaTT,
                               TenDayDu = b.TenDayDu,
                               MaMau = b.MaMau,
                               Gia = b.Gia,
                               Anh = b.Anh,
                               MauSac = c.MauSac1,
                               MaDL = b.MaDL,
                               BoNho = e.BoNho,
                               Ram = a.Ram,
                               CamChinh = a.CamChinh,
                               CamPhu = a.CamPhu,
                               CPU = a.CPU,
                               DoPhanGiai = a.DoPhanGiai,
                               DLPin = a.DLPin,
                               HeDH = a.HeDH,
                               KTManHinh = a.KTManHinh,
                               ID = iddmsp,
                               Ten = f.Ten,
                               Url = f.Url,
                               DaCap = f.DaCap
                           }).ToList();
            return sanpham;
        }
        public List<SanPhamViewModel> ListSPtheoDMSPCha(string idlsp)
        {
            var sanpham = (from a in db.SanPhams
                           join b in db.MauSanPhams on a.MaSP equals b.MaSP
                           join c in db.MauSacs on b.MaMau equals c.MaMau
                           join d in db.TinhTrangMays on b.MaTT equals d.MaTT
                           join e in db.DungLuongs on b.MaDL equals e.MaDL
                           join f in db.DanhMucSanPhams on a.DMSPID equals f.ID
                           join g in db.LoaiSanPhams on f.MaLSP equals g.MaLSP
                           where g.MaLSP == idlsp
                           select new SanPhamViewModel()
                           {
                               MaSP = b.MaSP,
                               MaTT = b.MaTT,
                               TenDayDu = b.TenDayDu,
                               MaMau = b.MaMau,
                               Gia = b.Gia,
                               Anh = b.Anh,
                               MauSac = c.MauSac1,
                               MaDL = b.MaDL,
                               BoNho = e.BoNho,
                               Ram = a.Ram,
                               CamChinh = a.CamChinh,
                               CamPhu = a.CamPhu,
                               CPU = a.CPU,
                               DoPhanGiai = a.DoPhanGiai,
                               DLPin = a.DLPin,
                               HeDH = a.HeDH,
                               KTManHinh = a.KTManHinh,
                               ID = f.ID,
                               Ten = f.Ten,
                               Url = f.Url,
                               DaCap = f.DaCap,
                               MaLSP = idlsp
                           }).ToList();
            return sanpham;
        }
        public bool XoaSP(string masp, string mamau, string madl, string matt)
        {
            var sp = db.MauSanPhams.Where(x=>x.MaSP == masp && x.MaMau == mamau && x.MaTT == matt && x.MaDL == madl).SingleOrDefault();
            db.MauSanPhams.Remove(sp);
            db.SaveChanges();
            return true;
             
        }
        public bool DelSP(string masp)
        {
            try
            {
                var sp = db.SanPhams.Where(x => x.MaSP == masp).SingleOrDefault();
                db.SanPhams.Remove(sp);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool CapNhatSP(SanPham sp)
        {
            var sanpham = db.SanPhams.Where(x => x.MaSP == sp.MaSP).SingleOrDefault();
            sanpham.TenSP = sp.TenSP;
            sanpham.Url = sp.Url;
            sanpham.MaLSP = sp.MaLSP;
            sanpham.DMSPID = sp.DMSPID;
            sanpham.TongSL = sp.TongSL;
            sanpham.MoTa = sp.MoTa;
            sanpham.Ram = sp.Ram;
            sanpham.CamChinh = sp.CamChinh;
            sanpham.CamPhu = sp.CamPhu;
            sanpham.CPU = sp.CPU;
            sanpham.DLPin = sp.DLPin;
            sanpham.DoPhanGiai = sp.DoPhanGiai;
            sanpham.HeDH = sp.HeDH;
            sanpham.KTManHinh = sp.KTManHinh;
            sanpham.ChiTiet = sp.ChiTiet;
            db.SaveChanges();
            return true;
        }
        public bool CapNhatCTSP(MauSanPham ctsp)
        {
            var sanpham = db.MauSanPhams.Where(x=>x.MaSP == ctsp.MaSP && x.MaMau == ctsp.MaMau && x.MaDL == ctsp.MaDL && x.MaTT == ctsp.MaTT).SingleOrDefault();
            sanpham.TenDayDu = ctsp.TenDayDu;
            sanpham.Anh = ctsp.Anh;
            sanpham.Url = ctsp.Url;
            sanpham.Gia = ctsp.Gia;
            sanpham.SoLuongCon = ctsp.SoLuongCon;
            db.SaveChanges();
            return true;
        }
        public IEnumerable<MauSanPham> ListSanPham(int page, int pageSize)
        {
            return db.MauSanPhams.OrderByDescending(x => x.MaSP).ToPagedList(page,pageSize);
        }
        public SanPham SanPham(string masp)
        {
            return db.SanPhams.Where(x => x.MaSP == masp).SingleOrDefault();
        }
        public MauSanPham ChiTietSanPham(string masp, string mamau, string madl, string matt)
        {
            return db.MauSanPhams.Where(x => x.MaSP == masp && x.MaMau == mamau && x.MaTT == matt && x.MaDL == madl).SingleOrDefault();
        }
        public DanhMucSanPham ChiTietDMSP(string id)
        {
            return db.DanhMucSanPhams.Where(x => x.ID == id).SingleOrDefault();
        }
        public bool ThemSP(SanPham sp)
        {
            var id = db.SanPhams.ToList();
            int maxIPhone = 0;
            int maxIPad = 0;
            int maxAPW = 0;
            foreach (var item in id)
            {
                if (item.MaLSP == "DT")
                {
                    string maChuSo = item.MaSP;
                    int so = Convert.ToInt32(maChuSo.Remove(0, 2));
                    if (maxIPhone < so)
                    {
                        maxIPhone = so;
                    }
                }
                else if (item.MaLSP == "MTB")
                {
                    string maChuSo = item.MaSP;
                    int so = Convert.ToInt32(maChuSo.Remove(0, 2));
                    if (maxIPad < so)
                    {
                        maxIPad = so;
                    }
                }
                else
                {
                    string maChuSo = item.MaSP;
                    int so = Convert.ToInt32(maChuSo.Remove(0, 2));
                    if (maxAPW < so)
                    {
                        maxAPW = so;
                    }
                }
            }
            if (sp.MaLSP == "DT")
            {
                if (maxIPhone + 1 < 10)
                {
                    sp.MaSP = "IP0" + (maxIPhone + 1).ToString();
                    db.SanPhams.Add(sp);
                }
                else
                {
                    sp.MaSP = "IP" + (maxIPhone + 1).ToString();
                    db.SanPhams.Add(sp);
                }
            }
            else if (sp.MaLSP == "MTB")
            {
                if (maxIPad + 1 < 10)
                {
                    sp.MaSP = "IA0" + (maxIPad + 1).ToString();
                    db.SanPhams.Add(sp);
                }
                else
                {
                    sp.MaSP = "IA" + (maxIPad + 1).ToString();
                    db.SanPhams.Add(sp);
                }
            }
            else
            {
                if (maxAPW + 1 < 10)
                {
                    sp.MaSP = "AW0" + (maxAPW + 1).ToString();
                    db.SanPhams.Add(sp);
                }
                else
                {
                    sp.MaSP = "AW" + (maxAPW + 1).ToString();
                    db.SanPhams.Add(sp);
                }
            }
            db.SaveChanges();
            return true;
        }
        public bool ThemCTSP(MauSanPham ctsp)
        {
            db.MauSanPhams.Add(ctsp);
            db.SaveChanges();
            return true;
        }
        public bool ThemDMSP(DanhMucSanPham dmsp)
        {
            var id = db.DanhMucSanPhams.ToList();
            int maxIPhone = 0;
            int maxIPad = 0;
            int maxAPW = 0;
            foreach (var item in id)
            {
                if (item.MaLSP == "DT")
                {
                    string maChuSo = item.ID;
                    int so = Convert.ToInt32(maChuSo.Remove(0, 3));
                    if (maxIPhone < so)
                    {
                        maxIPhone = so;
                    }
                }
                else if(item.MaLSP == "MTB")
                {
                    string maChuSo = item.ID;
                    int so = Convert.ToInt32(maChuSo.Remove(0, 3));
                    if (maxIPad < so)
                    {
                        maxIPad = so;
                    }
                }
                else
                {
                    string maChuSo = item.ID;
                    int so = Convert.ToInt32(maChuSo.Remove(0, 3));
                    if (maxAPW < so)
                    {
                        maxAPW = so;
                    }
                }
            }
            if (dmsp.MaLSP == "DT")
            {
                if (maxIPhone + 1 < 10)
                {
                    dmsp.ID = "IPh0" + (maxIPhone + 1).ToString();
                    db.DanhMucSanPhams.Add(dmsp);
                }
                else
                {
                    dmsp.ID = "IPh" + (maxIPhone + 1).ToString();
                    db.DanhMucSanPhams.Add(dmsp);
                }
            }
            else if(dmsp.MaLSP == "MTB")
            {
                if (maxIPad + 1 < 10)
                {
                    dmsp.ID = "IPa0" + (maxIPad + 1).ToString();
                    db.DanhMucSanPhams.Add(dmsp);
                }
                else
                {
                    dmsp.ID = "IPa" + (maxIPad + 1).ToString();
                    db.DanhMucSanPhams.Add(dmsp);
                }
            }
            else
            {
                if (maxAPW + 1 < 10)
                {
                    dmsp.ID = "APW0" + (maxAPW + 1).ToString();
                    db.DanhMucSanPhams.Add(dmsp);
                }
                else
                {
                    dmsp.ID = "APW" + (maxAPW + 1).ToString();
                    db.DanhMucSanPhams.Add(dmsp);
                }
            }
            db.SaveChanges();
            return true;
        }
        public bool CapNhatDMSP(DanhMucSanPham dmsp)
        {
            var dbDMSP = db.DanhMucSanPhams.Where(x => x.ID == dmsp.ID).SingleOrDefault();
            dbDMSP.Ten = dmsp.Ten;
            dbDMSP.Url = dmsp.Url;
            dbDMSP.DaCap = dmsp.DaCap;
            dbDMSP.MaLSP = dmsp.MaLSP;
            db.SaveChanges();
            return true;
        }
        public bool XoaDMSP(string iddmsp)
        {
            var listsp = db.SanPhams.Where(x => x.DMSPID == iddmsp).ToList();
            var dmsp = db.DanhMucSanPhams.Where(x => x.ID == iddmsp).SingleOrDefault();
            if(listsp.Count == 0)
            {
                db.DanhMucSanPhams.Remove(dmsp);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<SanPham> ListMaSP()
        {
            return db.SanPhams.ToList();
        }
        public List<DungLuong> ListMaDL()
        {
            return db.DungLuongs.ToList();
        }
        public List<MauSac> ListMaMau()
        {
            return db.MauSacs.ToList();
        }
        public List<TinhTrangMay> ListMaTT()
        {
            return db.TinhTrangMays.ToList();
        }
        public List<LoaiSanPham> ListMaLSP()
        {
            return db.LoaiSanPhams.ToList();
        }
        public List<DanhMucSanPham> ListDaCap()
        {
            return db.DanhMucSanPhams.Where(x => x.DaCap == null).ToList();
        }
        public List<DanhMucSanPham> ListDMSP()
        {
            return db.DanhMucSanPhams.ToList();
        }
        public List<SanPhamViewModel> ListSPLienQuan(string iddmsp, string masp, string mamau, string matt, string madl)
        {
            var sanpham = (from a in db.SanPhams
                           join b in db.MauSanPhams on a.MaSP equals b.MaSP
                           join c in db.MauSacs on b.MaMau equals c.MaMau
                           join d in db.TinhTrangMays on b.MaTT equals d.MaTT
                           join e in db.DungLuongs on b.MaDL equals e.MaDL
                           join f in db.DanhMucSanPhams on a.DMSPID equals f.ID
                           join g in db.LoaiSanPhams on a.MaLSP equals g.MaLSP
                           select new SanPhamViewModel()
                           {
                               MaSP = b.MaSP,
                               MaTT = b.MaTT,
                               TenDayDu = b.TenDayDu,
                               MaMau = b.MaMau,
                               Gia = b.Gia,
                               Anh = b.Anh,
                               MaDL = b.MaDL,
                               DMSPID = a.DMSPID
                           }).Where(x=>x.DMSPID == iddmsp && !(x.MaSP == masp && x.MaTT == matt && x.MaDL == madl && x.MaMau == mamau)).ToList();
            return sanpham;
        }
        public List<SanPhamViewModel> ChonMau(string iddmsp, string masp, string mamau, string matt, string madl)

        {
            var mau = (from a in db.SanPhams
                           join b in db.MauSanPhams on a.MaSP equals b.MaSP
                           join c in db.MauSacs on b.MaMau equals c.MaMau
                           join d in db.TinhTrangMays on b.MaTT equals d.MaTT
                           join f in db.DanhMucSanPhams on a.DMSPID equals f.ID
                           select new SanPhamViewModel()
                           {
                               MaSP = b.MaSP,
                               MaTT = b.MaTT,
                               MaMau = b.MaMau,
                               MaDL = b.MaDL,
                               DMSPID = a.DMSPID,
                               MauSac = c.MauSac1
                           }).Where(x => x.MaSP == masp).ToList();
            return mau;
        }
       
        public DanhMucSanPham LayTenDMSP(string iddmsp)
        {
            return db.DanhMucSanPhams.Where(x => x.ID == iddmsp).SingleOrDefault();
        }
        public string LayTenLSP(string idlsp)
        {
            return db.LoaiSanPhams.Where(x => x.MaLSP == idlsp).Select(x => x.TenLSP).SingleOrDefault();
        }
        public List<MauSanPham> ListSP()
        {
            return db.MauSanPhams.ToList();
        }
        public List<ThongKeSPViewModel> ThongKeSP()
        {
            var sanpham = (from a in db.SanPhams
                           select new ThongKeSPViewModel()
                           {
                               TenSP = a.TenSP,
                               TongSL = a.TongSL
                           }).Where(x=>x.TongSL > 0).ToList();
            return sanpham;
        }
        public List<SanPhamViewModel> LocSanPham(string iddmsp, decimal? giaMin, decimal? giaMax)
        {
            var sanpham = (from a in db.SanPhams
                           join b in db.MauSanPhams on a.MaSP equals b.MaSP
                           where a.DMSPID == iddmsp
                           select new SanPhamViewModel()
                           {
                               MaSP = b.MaSP,
                               MaTT = b.MaTT,
                               TenDayDu = b.TenDayDu,
                               MaMau = b.MaMau,
                               Gia = b.Gia,
                               Anh = b.Anh,
                               MaDL = b.MaDL,
                               ID = iddmsp
                           }).Where(x=>x.Gia >= giaMin && x.Gia<= giaMax).ToList();
            return sanpham;
        }
        public int CheckSLCon(MauSanPham sp)
        {
            var sanpham = db.MauSanPhams.Where(x => x.MaSP == sp.MaSP && x.MaTT == sp.MaTT && x.MaDL == sp.MaDL && x.MaMau == sp.MaMau).SingleOrDefault();
            return sanpham.SoLuongCon;
        }
        public List<SPBanRaViewModel> SPBanRa(int? thang, int nam)
        {
            int sl = 0;
            var tongSPBanRa = (from a in db.SanPhams
                           join b in db.ChiTietDonHangs on a.MaSP equals b.MaSP
                           join f in db.DonHangs on b.MaDH equals f.MaDH
                           where f.TrangThai == "Đã nhận hàng" && f.NgayBan.Month == thang && f.NgayBan.Year == nam && f.MaDH == b.MaDH
                           select new SPBanRaViewModel()
                           {
                               TenSP = a.TenSP,
                               MaSP = a.MaSP,
                               MaDL = b.MaDL,
                               MaTT = b.MaTT,
                               MaMau = b.MaMau,
                               SoLuong = b.SoLuong
                           }).ToList();
            var list = new List<SPBanRaViewModel>();
            foreach (var item in tongSPBanRa)
            {
                if (list.Exists((x => x.MaSP == item.MaSP)))
                {
                    foreach(var sp in list)
                    {
                        if (sp.MaSP == item.MaSP)
                        {
                            sp.SoLuong += item.SoLuong;
                        }
                    }
                }
                else
                {
                    list.Add(new SPBanRaViewModel
                    {
                        MaSP = item.MaSP,
                        Thang = thang,
                        Nam = nam,
                        TenSP = item.TenSP,
                        SoLuong = item.SoLuong
                    });
                }
            }
            return list;
            
            
        }
    }
}
