using Model.DAO;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Model.EF;
using OnlineShop.Common;
using Common;
using System.Configuration;

namespace OnlineShop.Controllers
{
    public class GioHangController : Controller
    {
        OnlineShopDbContext db = new OnlineShopDbContext();
        private const string CartSession = "CartSession";
        // GET: GioHang
        public ActionResult Index()
        {
            var giohang = Session[CartSession];
            var list = new List<GioHang>();
            if (giohang != null)
            {
                list = (List<GioHang>)giohang;
            }

            return View(list);
        }
        public ActionResult ThemGioHang(string masp,string mamau,string matt,string madl, int soluong)
        {
            var mausp = new SanPhamDao().ViewDetail(masp, mamau, matt, madl);
            var giohang = Session[CartSession];
            var slcon = new SanPhamDao().CheckSLCon(mausp);
            if (giohang != null)
            {
                var list = (List<GioHang>)giohang;
                if (   list.Exists((x => x.MauSanPham.MaSP == masp))
                    && list.Exists((x => x.MauSanPham.MaMau == mamau))
                    && list.Exists((x => x.MauSanPham.MaTT == matt))
                    && list.Exists((x => x.MauSanPham.MaDL == madl))
                    )
                {
                       foreach (var sp in list){
                                if (sp.MauSanPham.MaSP == masp && sp.MauSanPham.MaMau == mamau && sp.MauSanPham.MaTT == matt && sp.MauSanPham.MaDL == madl)
                                {
                                    sp.SoLuong += soluong;
                                    if(sp.SoLuong > slcon)
                                    {
                                        sp.SoLuong -= soluong;
                                        return View("Error");
                                    }
                                }
                        }
                    
                }
                
                else
                {
                    // tạo mới đối tượng card item
                    var item = new GioHang();
                    if (slcon > 0 && item.SoLuong <= slcon)
                    {
                        item.MauSanPham = mausp;
                        item.SoLuong = soluong;
                        list.Add(item);
                        Session[CartSession] = list;
                    }
                    else
                    {
                        return View("HetHang");
                    }
                }

            }
            else
            {
                // tạo mới đối tượng card item
                var item = new GioHang();
                item.MauSanPham = mausp;
                if (slcon > 0 && item.SoLuong <= slcon )
                {
                    item.SoLuong = soluong;
                    var list = new List<GioHang>();
                    list.Add(item);
                    Session[CartSession] = list;
                }
                else
                {
                    return View("HetHang");
                }
            }
            return RedirectToAction("Index");
        }
        public JsonResult CapNhat(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<GioHang>>(cartModel);
            var sessionCart = (List<GioHang>)Session[CartSession];
            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.MauSanPham.MaSP == item.MauSanPham.MaSP
                && x.MauSanPham.MaMau == item.MauSanPham.MaMau && x.MauSanPham.MaTT == item.MauSanPham.MaTT && x.MauSanPham.MaDL == item.MauSanPham.MaDL);
                if(jsonItem != null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult XoaGioHang()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult XoaSP(string masp, string mamau, string matt, string madl)
        {
            var sessionCart = (List<GioHang>)Session[CartSession];
            sessionCart.RemoveAll(x => x.MauSanPham.MaSP == masp && x.MauSanPham.MaMau == mamau && x.MauSanPham.MaTT == matt && x.MauSanPham.MaDL == madl);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        [HttpGet]
        public ActionResult ThanhToan()
        {
            var giohang = Session[CartSession];
            ViewBag.userSession = Session[CommonConstant.USER_SESSION];
            var list = new List<GioHang>();
            if (giohang != null)
            {
                list = (List<GioHang>)giohang;
            }

            return View(list);
        }
        [HttpPost]
        public ActionResult ThanhToan(string HoTen, string SDT, string Email, string DiaChiNhan)
        {
            decimal tongtien = 0;
            decimal thanhtien = 0;
            ViewBag.userSession = Session[CommonConstant.USER_SESSION];
                var listSP = new SanPhamDao().ListSP();
                var gioHang = (List<GioHang>)Session[CartSession];
                var ctdhDAO = new ChiTietDonHangDao();
                var donHang = new DonHang();
                int dem = 0;
                donHang.NgayBan = DateTime.Now;
                donHang.HoTen = HoTen;
                donHang.SDT = SDT;
                donHang.Email = Email;
                donHang.DiaChiNhan = DiaChiNhan;
                donHang.TongTien = tongtien;
                donHang.TrangThai = "Chờ duyệt";
                if (ViewBag.userSession != null)
                {
                    donHang.MaKH = ViewBag.userSession.ID;
                }
                else
                {

                }
                var addDH = new DonHangDao().Insert(donHang);
                foreach (var sp in listSP)
                {
                   foreach (var item in gioHang)
                    {
                        if (item.SoLuong <= sp.SoLuongCon && item.MauSanPham.MaSP == sp.MaSP && item.MauSanPham.MaMau == sp.MaMau && item.MauSanPham.MaDL == sp.MaDL && item.MauSanPham.MaTT == sp.MaTT)
                        {
                            dem += 1;
                            tongtien = thanhtien + item.MauSanPham.Gia*item.SoLuong;
                            var ctdh = new ChiTietDonHang();
                            ctdh.MaDH = donHang.MaDH;
                            ctdh.MaSP = item.MauSanPham.MaSP;
                            ctdh.MaMau = item.MauSanPham.MaMau;
                            ctdh.MaTT = item.MauSanPham.MaTT;
                            ctdh.MaDL = item.MauSanPham.MaDL;
                            ctdh.SoLuong = item.SoLuong;
                            ctdhDAO.Insert(ctdh);
                        }
                        else
                        {

                        }
                    }
                }
                if (dem > 0)
                {
                    // Gửi mail
                    string mail = System.IO.File.ReadAllText(Server.MapPath("~/Asset/client/template/DonHangMoi.html"));
                    
                    mail = mail.Replace("{{MaDH}}", donHang.MaDH.ToString());
                    mail = mail.Replace("{{HoTen}}", HoTen);
                    mail = mail.Replace("{{SDT}}", SDT);
                    mail = mail.Replace("{{Email}}", Email);
                    mail = mail.Replace("{{DiaChiNhan}}", DiaChiNhan);
                    mail = mail.Replace("{{TongTien}}", string.Format("{0:#,##}", tongtien));

                    var emailAdmin = ConfigurationManager.AppSettings["EmailAdmin"].ToString();
                    new Mail().GuiMail(Email,"Đơn hàng của bạn", mail);
                    new Mail().GuiMail(emailAdmin, "Khách vừa đặt hàng", mail);

                    gioHang = null;
                    return Redirect("/hoan-thanh");
                }
                else
                {
                    Session[CartSession] = null;
                    var del = db.DonHangs.Where(x => x.MaDH ==addDH).FirstOrDefault();
                    db.DonHangs.Remove(del);
                    db.SaveChanges();
                    return View("Error");
                }
            
        }
        public ActionResult HoanThanh()
        {
            return View();
        }
    }
}