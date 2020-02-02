using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: SanPham
        OnlineShopDbContext db = new OnlineShopDbContext();
        public ActionResult Index()
        {
            var sp = new SanPhamDao().ListAll();
            return View(sp);
        }
    }
}