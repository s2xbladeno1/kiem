using Model.DAO;
using Model.EF;
using OnlineShop.Common;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class SanPhamController : BaseController
    {
        // GET: Admin/SanPham

        [QuyenUser(QuyenID = "view_sp")]
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var sp = new SanPhamDao().SanPham(page, pageSize);
            return View(sp);
        }
        [QuyenUser(QuyenID = "view_sp")]
        public ActionResult ListSanPham(int page = 1, int pageSize = 10)
        {
            var listsp = new SanPhamDao().ListSanPham(page,pageSize);
            return View(listsp);
        }
        [QuyenUser(QuyenID = "view_dmsp")]
        public ActionResult DanhMucSanPham(int page =1 , int pageSize = 5)
        {
            var dmsp = new SanPhamDao().ListDMSP(page,pageSize);
            return View(dmsp);
        }
        [QuyenUser(QuyenID = "del_sp")]
        public JsonResult XoaSP(string masp, string mamau, string madl, string matt)
        {
            var xoasp = new SanPhamDao().XoaSP(masp, mamau, madl, matt);
            return Json(new
            {
                status = true
            });
        }

        [QuyenUser(QuyenID = "del_sp")]
        public JsonResult DelSP(string masp)
        {
            var xoasp = new SanPhamDao().DelSP(masp);
            if (xoasp == true)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
        [QuyenUser(QuyenID = "edit_sp")]
        public ActionResult CapNhatSP(string masp)
        {
            var sp = new SanPhamDao().SanPham(masp);
            GetListDMSP();
            return View(sp);
        }
        [HttpPost]
        [QuyenUser(QuyenID = "edit_sp")]
        public ActionResult CapNhatSP(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                var kq = new SanPhamDao().CapNhatSP(sp);
                if (kq == true)
                {
                    return RedirectToAction("Index", "SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
            }
            return View("Index");
        }
        [QuyenUser(QuyenID = "edit_sp")]
        public ActionResult CapNhatCTSP(string masp, string mamau, string madl, string matt)
        {
            var sp = new SanPhamDao().ChiTietSanPham(masp, mamau, madl, matt);
            return View(sp);
        }
        [HttpPost]
        [QuyenUser(QuyenID = "edit_sp")]
        public ActionResult CapNhatCTSP(MauSanPham ctsp)
        {
            if (ModelState.IsValid)
            {
                var kq = new SanPhamDao().CapNhatCTSP(ctsp);
                if (kq == true)
                {
                    return RedirectToAction("ListSanPham", "SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
            }
            return View("ListSanPham");
        }

        [HttpGet]
        [QuyenUser(QuyenID = "add_sp")]
        public ActionResult ThemSP()
        {
            GetListDMSP();
            return View();
        }
        [HttpPost]
        [QuyenUser(QuyenID = "add_sp")]
        public ActionResult ThemSP(SanPham sp)
        {
            
            if (ModelState.IsValid)
            {
                var kq = new SanPhamDao().ThemSP(sp);
                if (kq == true)
                {
                    return RedirectToAction("Index", "SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm thất bại");
                }
            }
            return View("Index");
        }

        [HttpGet]
        [QuyenUser(QuyenID = "add_sp")]
        public ActionResult ThemCTSP(string masp)
        {
            SetViewBag();
            ViewBag.SP = new SanPhamDao().SanPham(masp);
            return View();
        }
        public void SetViewBag(string selectedMaSP = null)
        {
            ViewBag.MaSP = new SelectList(new SanPhamDao().ListMaSP(), "MaSP", "TenSP", selectedMaSP);
            ViewBag.MaMau = new SelectList(new SanPhamDao().ListMaMau(), "MaMau", "MauSac1", selectedMaSP);
            ViewBag.MaDL = new SelectList(new SanPhamDao().ListMaDL(), "MaDL", "BoNho", selectedMaSP);
            ViewBag.MaTT = new SelectList(new SanPhamDao().ListMaTT(), "MaTT", "MoTa", selectedMaSP);
        }
        [HttpPost]
        [QuyenUser(QuyenID = "add_sp")]
        public ActionResult ThemCTSP(MauSanPham ctsp)
        {
            if (ModelState.IsValid)
            {
                var kq = new SanPhamDao().ThemCTSP(ctsp);
                if(kq == true)
                {
                    return RedirectToAction("ListSanPham","SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm thất bại");
                }
            }
            return View("ListSanPham");
        }
        public void GetListDMSP(string selected = null)
        {
            ViewBag.MaLSP = new SelectList(new SanPhamDao().ListMaLSP(), "MaLSP", "TenLSP", selected);
            ViewBag.DaCap = new SelectList(new SanPhamDao().ListDaCap(), "ID", "Ten", selected);
            ViewBag.DMSPID = new SelectList(new SanPhamDao().ListDMSP(), "ID", "Ten", selected);
        }
        [QuyenUser(QuyenID = "add_dmsp")]
        public ActionResult ThemDMSP()
        {
            GetListDMSP();
            return View();
        }
        [HttpPost]
        [QuyenUser(QuyenID = "add_dmsp")]
        public ActionResult ThemDMSP(DanhMucSanPham dmsp)
        {
            if (ModelState.IsValid)
            {
                var kq = new SanPhamDao().ThemDMSP(dmsp);
                if (kq == true)
                {
                    return RedirectToAction("DanhMucSanPham", "SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm danh mục sản phẩm thất bại");
                }
            }
            return View("DanhMucSanPham");
        }
        [QuyenUser(QuyenID = "edit_dmsp")]
        public ActionResult CapNhatDMSP(string iddmsp)
        {
            var dmsp = new SanPhamDao().ChiTietDMSP(iddmsp);
            GetListDMSP(dmsp.ID);
            return View(dmsp);
        }
        [HttpPost]
        [QuyenUser(QuyenID = "edit_dmsp")]
        public ActionResult CapNhatDMSP(DanhMucSanPham dmsp)
        {
            if (ModelState.IsValid)
            {
                var kq = new SanPhamDao().CapNhatDMSP(dmsp);
                if (kq == true)
                {
                    return RedirectToAction("DanhMucSanPham", "SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm thất bại");
                }
            }
            return View("DanhMucSanPham");
        }
        [QuyenUser(QuyenID = "del_dmsp")]
        public JsonResult XoaDMSP(string iddmsp)
        {
            var del = new SanPhamDao().XoaDMSP(iddmsp);
            if(del == true)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
    }
}