using BotDetect.Web.Mvc;
using Model.DAO;
using Model.EF;
using OnlineShop.Common;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class UserController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: User
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "DangKyCaptcha", "Mã xác nhận không đúng!")]
        public ActionResult DangKy(DangKyModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if(dao.CheckTK(model.TaiKhoan) == true)
                {
                    ModelState.AddModelError("","Tên đăng nhập đã tồn tại");
                }
                else if(dao.CheckEmail(model.Email) == true){
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new NguoiDung();
                    user.TaiKhoan = model.TaiKhoan;
                    user.MatKhau = MaHoaMD5.MD5Hash(model.MatKhau);
                    user.HoTen = model.HoTen;
                    user.Email = model.Email;
                    user.SDT = model.SDT;
                    user.TinhTrang = true;
                    var add = dao.Insert(user);
                    if (add > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new DangKyModel();
                        return View("Success");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                }
            }
            return View(model);
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(DangNhapModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var kq = dao.Login(model.TaiKhoan, MaHoaMD5.MD5Hash(model.MatKhau));
                if (kq == 1)
                {
                    Session[CartSession] = null;
                    var user = dao.getByTK(model.TaiKhoan);
                    var userSession = new UserLogin();
                    userSession.TaiKhoan = user.TaiKhoan;
                    userSession.ID = user.ID;
                    userSession.GroupID = user.GroupID;
                    userSession.HoTen = user.HoTen;
                    userSession.SDT = user.SDT;
                    userSession.Email = user.Email;
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");

                }
                else if (kq == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (kq == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else if (kq == -2)
                {
                    ModelState.AddModelError("", "Sai mật khẩu");
                }
                else if (kq == -3)
                {
                    ModelState.AddModelError("", "Bạn không có quyền truy cập vào trang web này");
                }
            }
            return View(model);
        }
        public ActionResult DangXuat()
        {
            
            Session[CommonConstant.USER_SESSION] = null;
            Session[CartSession] = null;
            return Redirect("/");
        }
        public ActionResult DoiMatKhau()

        {
            
            var userSession = Session[CommonConstant.USER_SESSION];
            if (userSession != null)
            {
                return View();
            }
            else
            {
                return View("DangNhap");
            }
        }
        [HttpPost]
        public ActionResult DoiMatKhau(DoiMatKhauModel model)
        {
            ViewBag.userSession = Session[CommonConstant.USER_SESSION];
            var dmkDAO = new UserDao().DoiMatKhau(ViewBag.userSession.ID, MaHoaMD5.MD5Hash(model.MatKhauCu), MaHoaMD5.MD5Hash(model.MatKhau));
            if (dmkDAO == true)
            {
                return View("dmkOKE");
            }
            else
            {
                return View();
            }
        }
        public ActionResult TheoDoiDonHang()
        {
            var userSession = Session[CommonConstant.USER_SESSION];
            ViewBag.userSession = Session[CommonConstant.USER_SESSION];
            if(userSession == null)
            {
                return View("DangNhap");
            }
            else
            {
                ViewBag.DonHang = new DonHangDao().LichSuDatHang().Where(x => x.MaKH == ViewBag.userSession.ID).ToList();
                return View(ViewBag.DonHang);
            }
        }
        public ActionResult ChiTietDonHang(int madh)
        {
            var ctdh = new ChiTietDonHangDao().ChiTietDonHang(madh);
            ViewBag.ttDonHang = new DonHangDao().oneDonHang(madh);
            return View(ctdh);
        }
    }
}