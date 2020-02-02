using Model.DAO;
using Model.EF;
using Model.ViewModel;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class DoanhThuController : Controller
    {
        // GET: Admin/DoanhThu
        [QuyenUser(QuyenID = "view_tk")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [QuyenUser(QuyenID = "view_tk")]
        public ActionResult GetThongKeSP()
        {
            var list = new SanPhamDao().ThongKeSP();
            var sp = new List<ThongKeSPViewModel>();
            foreach (var item in list)
            {
                sp.Add(new ThongKeSPViewModel { TenSP = item.TenSP, TongSL = item.TongSL });
            }
            return Json(sp, JsonRequestBehavior.AllowGet);
        }
        [QuyenUser(QuyenID = "view_tk")]
        public ActionResult DoanhThuThang()
        {
            return View();
        }
        [HttpPost]
        [QuyenUser(QuyenID = "view_tk")]
        public ActionResult GetDoanhThuTheoThang()
        {
            var list = new List<DoanhThuViewModel>();
            decimal doanhthu, tongnhap, loinhuan;
            var nam = DateTime.Now.Year;
            for (int j = 2019; j <= nam; j++)
            {
                for (int i = 1; i <= 12; i++)
                {
                    tongnhap = new NhapHangDao().TongNhap(i, j);
                    doanhthu = new DonHangDao().DoanhThuTheoThang(i, j);
                    loinhuan = doanhthu - tongnhap;
                    if (doanhthu != 0)
                    {
                        list.Add(new DoanhThuViewModel { Thang = i, Nam = j, TongNhap = tongnhap, DoanhThu = doanhthu, LoiNhuan = loinhuan });
                    }
                }
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [QuyenUser(QuyenID = "view_tk")]
        public ActionResult ThongKeSPBanRa()
        {
            return View();
        }
        [QuyenUser(QuyenID = "view_tk")]
        [HttpPost]
        public ActionResult ThongKeSPBanRaTheoThang()
        {
            int Thang = DateTime.Now.Month;
            int Nam = DateTime.Now.Year;
            var list = new List<SPBanRaViewModel>();
            var spBanRa = new SanPhamDao().SPBanRa(Thang, Nam);
            foreach (var item in spBanRa)
            {
                if (item.SoLuong != 0)
                {
                    list.Add(new SPBanRaViewModel
                    {
                        MaSP = item.MaSP,
                        MaDL = item.MaDL,
                        MaTT = item.MaTT,
                        MaMau = item.MaMau,
                        Thang = Thang,
                        Nam = Nam,
                        TenSP = item.TenSP,
                        SoLuong = item.SoLuong
                    });
                }
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}