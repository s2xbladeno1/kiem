using Model.DAO;
using Model.EF;
using Model.ViewModel;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace OnlineShop.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
          OnlineShopDbContext db = new OnlineShopDbContext();
        public ActionResult LoaiSanPham(string idlsp)
        {
            var sp = new SanPhamDao().ListSPtheoDMSPCha(idlsp).Where(x=>x.MaLSP == idlsp).ToList();
            ViewBag.TenLSP = new SanPhamDao().LayTenLSP(idlsp);
            return View(sp);
        }
        
        public ActionResult ChiTietSP(string iddmsp, string masp, string mamau, string matt, string madl, int? mabl)
    {
            var ctsp = new SanPhamDao().ListAll().Where(x => x.MaSP == masp && x.MaMau == mamau && x.MaTT == matt && x.MaDL == madl).SingleOrDefault();
            ViewBag.sptuongtu = new SanPhamDao().ListSPLienQuan(iddmsp,masp, mamau, matt, madl);
            ViewBag.chonMau = new SanPhamDao().ChonMau(iddmsp, masp, mamau, matt, madl);
            ViewBag.BinhLuan = new BinhLuanDao().ListDanhGiaSP(iddmsp,masp, mamau, matt, madl);
            ViewBag.user = Session[CommonConstant.USER_SESSION];
            ViewBag.danhGia = new BinhLuanDao().DiemDanhGia(masp, mamau, matt, madl);
            ViewBag.replyCMT = new BinhLuanDao().ReplyDanhGia(masp, mamau, matt, madl);
            ViewBag.TenNguoiDanhGia = new BinhLuanDao().TenNguoiDanhGia(mabl, masp, mamau, matt, madl);
            return View(ctsp);
        }
        
        [HttpPost]
        public ActionResult ChiTietSP(DanhGiaSPViewModel dgsp, string masp, string mamau, string matt, string madl)
        {
            
            ViewBag.user = Session[CommonConstant.USER_SESSION];
            var nhanVien = new UserDao().getGroupID(ViewBag.user.ID);
            if (ViewBag.user == null)
            {
                return View("Error_ChuaLogin");
            }
            else
            {
                var soLanMua = new BinhLuanDao().SoLanMuaCua1KH(dgsp.NguoiDungID, masp, mamau, matt, madl);
                var soLanDanhGia = new BinhLuanDao().SoLanDanhGia(dgsp.NguoiDungID, masp, mamau, matt, madl);
                if(soLanMua.Count > 0 || nhanVien == "NVBH")
                {
                    if (soLanDanhGia.Count < soLanMua.Count || nhanVien == "NVBH")
                    {
                        var rs = new BinhLuanDao().Insert(dgsp);
                        var ctsp = new SanPhamDao().ListAll().Where(x =>x.DMSPID == dgsp.ID && x.MaSP == masp && x.MaMau == mamau && x.MaTT == matt && x.MaDL == madl).SingleOrDefault();
                        ViewBag.sptuongtu = new SanPhamDao().ListSPLienQuan(dgsp.ID, masp, mamau, matt, madl);
                        ViewBag.chonMau = new SanPhamDao().ChonMau(dgsp.ID, masp, mamau, matt, madl);
                        ViewBag.BinhLuan = new BinhLuanDao().ListDanhGiaSP(dgsp.ID, masp, mamau, matt, madl);
                        ViewBag.danhGia = new BinhLuanDao().DiemDanhGia(masp, mamau, matt, madl);
                        ViewBag.replyCMT = new BinhLuanDao().ReplyDanhGia(masp, mamau, matt, madl);
                        return View(ctsp);
                    }
                    else
                    {
                        return View("Error_DanhGia");
                    }
                }
                else
                {
                    return View("Error");
                }
            }
            
        }
        public JsonResult GetNameToReply(int mabl, string masp, string mamau, string matt, string madl, string iddmsp)
        {
            return Json(new
            {
                status = true
            });
        }
        public JsonResult ListName(string term)
        {
            var data = new SanPhamDao().ListName(term);
            return Json(new
            {
                data = data,
                status = true
            },JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(string keyword)
        {
           
            var model = new SanPhamDao().Search(keyword);
            ViewBag.Keyword = keyword;
            return View(model);
        }
        [ChildActionOnly]
        public PartialViewResult MenuCha()
        {
            var listnamedmsp = new SanPhamDao().MenuCha();
            return PartialView(listnamedmsp);
        }
        public ActionResult DanhMucSanPham(string iddmsp)
        {
            var listsptheodm = new SanPhamDao().ListSPtheoDMSPCon(iddmsp).ToList();
            ViewBag.TenDMSP = new SanPhamDao().LayTenDMSP(iddmsp);
            return View(listsptheodm);
        }
        public ActionResult LocSanPham(string iddmsp, decimal? giaMin, decimal? giaMax)
        {
            var sp = new SanPhamDao().LocSanPham(iddmsp, giaMin, giaMax);
            return Json(new{ status = true } );
        }
    }
}