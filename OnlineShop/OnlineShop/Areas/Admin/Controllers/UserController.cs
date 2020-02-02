using Model.DAO;
using Model.EF;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        [QuyenUser(QuyenID ="view_user")]
        public ActionResult Index(string group, string SearchUser,int page = 1, int pageSize = 10)
        {
            if(group == null)
            {
                var model = new UserDao().ListUser(SearchUser, page, pageSize);
                ViewBag.SearchUser = SearchUser;
                return View(model);
            }
            else if(group == "MEMBER")
            {
                var model = new UserDao().ListMember(group, page, pageSize);
                ViewBag.SearchUser = SearchUser;
                return View(model);
            }
            else
            {
                var model = new UserDao().ListQTV(group, page, pageSize);
                ViewBag.SearchUser = SearchUser;
                return View(model);
            }
        }
        [HttpGet]
        [QuyenUser(QuyenID = "add_user")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [QuyenUser(QuyenID = "add_user")]
        public ActionResult Create(NguoiDung user)
        {
            if (ModelState.IsValid)
            {
                var mahoa = MaHoaMD5.MD5Hash(user.MatKhau);
                user.MatKhau = mahoa;
                int id = new UserDao().Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm người dùng thành công");
                }
            }
            return View("Index");
        }
        [QuyenUser(QuyenID = "lock_user")]
        public JsonResult Lock(int id, bool tt)
        {
            var savelock = new UserDao().SaveLock(id, tt);
            return Json(new
            {
                status = true
            });
        }
        public JsonResult ListMember(string group, int page = 1, int pageSize = 10)
        {
            var rs = new UserDao().ListMember(group, page, pageSize);
            return Json(new { status = true });
        }
        public JsonResult ListQTV(string group, int page = 1, int pageSize = 10)
        {
            var rs = new UserDao().ListQTV(group, page, pageSize);
            return Json(new { status = true });
        }
    }
}