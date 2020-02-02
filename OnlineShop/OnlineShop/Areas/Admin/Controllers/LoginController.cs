using Model.DAO;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var kq = dao.Login(model.TaiKhoan, MaHoaMD5.MD5Hash(model.MatKhau),true);
                if (kq == 1)
                {
                    var user = dao.getByTK(model.TaiKhoan);
                    var userSession = new UserLogin();
                    userSession.TaiKhoan = user.TaiKhoan;
                    userSession.ID = user.ID;
                    userSession.HoTen = user.HoTen;
                    userSession.GroupID = user.GroupID;
                    var listQuyenUser = dao.GetListQuyenUser(model.TaiKhoan);
                    Session.Add(CommonConstant.QUYENUSER_SESSION, listQuyenUser);
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                   
                }
                else if(kq == 0){
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
            return View("Index");
        }
    }
}