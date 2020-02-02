using Model.DAO;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class DonHangController : BaseController
    {
        // GET: Admin/DonHang
        public ActionResult Index()
        {
            
            return View();
        }
        [QuyenUser(QuyenID = "view_dh")]
        public ActionResult ListDonHang(string tt, int page = 1, int pageSize = 10)
        {
            if(tt == null)
            {
                var listdh = new DonHangDao().ListDonHang(page, pageSize);
                return View(listdh);
            }
            else
            {
                var dh = new DonHangDao().ListDHTheoTrangThai(tt, page, pageSize);
                return View(dh);
            }
        }
        [QuyenUser(QuyenID = "view_dh")]
        public ActionResult ChiTietDonHang(int madh)
        {
            var ctdh = new ChiTietDonHangDao().ChiTietDonHang(madh);
            ViewBag.ttDonHang = new DonHangDao().oneDonHang(madh);
            return View(ctdh);
        }
        [QuyenUser(QuyenID = "edit_dh")]
        public JsonResult CapNhat(int madh, string tt)
        {
            var dh = new DonHangDao().CapNhat(madh, tt);
            return Json(new
            {
                status = true
            });
        }

        public JsonResult JsonListDHTheoTrangThai(string tt,int page =1, int pageSize = 10)
        {
            var dh = new DonHangDao().ListDHTheoTrangThai(tt,page, pageSize);
            return Json(new
            {
                status = true
            });
        }
    }
}