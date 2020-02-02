using Model.DAO;
using Model.EF;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class NhapHangController : BaseController
    {
        // GET: Admin/NhapHang
        [QuyenUser(QuyenID = "view_nh")]
        public ActionResult Index()
        {
            var listNH = new NhapHangDao().ListNH();
            return View(listNH);
        }
        [QuyenUser(QuyenID = "add_nh")]
        public ActionResult NhapHang()
        {
            return View();
        }

        [HttpPost]
        [QuyenUser(QuyenID = "add_nh")]
        public ActionResult NhapHang(NhapHang nh)
        {
                var user = (UserLogin)Session[Common.CommonConstant.USER_SESSION];
                nh.NguoiNhap = user.ID;
                var kq = new NhapHangDao().Insert(nh);
                if (kq == true)
                {
                    return RedirectToAction("Index", "NhapHang");
                }
                else
                {
                    ModelState.AddModelError("", "Nhập hàng thất bại");
                }
            return View("Index");
        }
        [QuyenUser(QuyenID = "view_nh")]
        public ActionResult ChiTietNhapHang(int manh)
        {
            var ctnh = new ChiTietNhapHangDao().ListCTNH(manh);
            ViewBag.nhaphang = new NhapHangDao().oneNH(manh);
            return View(ctnh);
        }
        [QuyenUser(QuyenID = "add_nh")]
        public ActionResult AddChiTietNhapHang(int manh)
        {
            GetListNH();
            ViewBag.MaNH = new NhapHangDao().oneNH(manh);
            return View();
        }
        [HttpPost]
        [QuyenUser(QuyenID = "add_nh")]
        public ActionResult AddChiTietNhapHang(ChitietNhapHang ctnh)
        {
            if (ModelState.IsValid)
            {
                var kq = new ChiTietNhapHangDao().Insert(ctnh);
                if (kq == true)
                {
                    return RedirectToAction("Index", "NhapHang");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm thất bại");
                }
            }
            return View("Index");
        }
        [QuyenUser(QuyenID = "edit_nh")]
        public ActionResult EditChiTietNhapHang(int manh, string masp, string mamau, string matt, string madl)
        {
            var edit = new NhapHangDao().SanPham(manh,masp,mamau,matt,madl);
            return View(edit);
        }
        [HttpPost]
        [QuyenUser(QuyenID = "edit_nh")]
        public ActionResult EditChiTietNhapHang(ChitietNhapHang ctnh)
        {
            var rs = new NhapHangDao().EditChiTietNhapHang(ctnh);
            if (rs == true)
            {
                return RedirectToAction("Index", "NhapHang"); // return Chi tiết nhập hàng manh == ctnh.manh
            }
            else
            {
                ModelState.AddModelError("", "Update không thành công");
            }
            return View("Index");
        }
        [QuyenUser(QuyenID = "del_nh")]
        public JsonResult XoaItem(int manh, string masp, string mamau, string matt, string madl)
        {
            var rs = new NhapHangDao().XoaItem(manh, masp, mamau, matt, madl);
            return Json(new { status = true });
        }
        public void GetListNH(string selected = null)
        {
            ViewBag.MaSP = new SelectList(new SanPhamDao().ListMaSP(), "MaSP", "TenSP", selected);
            ViewBag.MaMau = new SelectList(new SanPhamDao().ListMaMau(), "MaMau", "MauSac1", selected);
            ViewBag.MaDL = new SelectList(new SanPhamDao().ListMaDL(), "MaDL", "BoNho", selected);
            ViewBag.MaTT = new SelectList(new SanPhamDao().ListMaTT(), "MaTT", "MoTa", selected);
            ViewBag.MaNH = new SelectList(new NhapHangDao().ListNH(), "MaNH", "MaNH", selected);
        }
    }
}