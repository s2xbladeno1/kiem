using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
               name: "Thêm giỏ hàng",
               url: "them-gio-hang",
               defaults: new { controller = "GioHang", action = "ThemGioHang", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }

           );
            routes.MapRoute(
              name: "Giỏ hàng",
              url: "gio-hang",
              defaults: new { controller = "GioHang", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "OnlineShop.Controllers" }

          );
            routes.MapRoute(
             name: "Thanh Toán",
             url: "thanh-toan",
             defaults: new { controller = "GioHang", action = "ThanhToan", id = UrlParameter.Optional },
             namespaces: new[] { "OnlineShop.Controllers" }

         );
            routes.MapRoute(
            name: "Loại sản phẩm",
            url: "loai-san-pham",
            defaults: new { controller = "SanPham", action = "LoaiSanPham", id = UrlParameter.Optional },
            namespaces: new[] { "OnlineShop.Controllers" }

        );
            routes.MapRoute(
            name: "Đặt hàng thành công",
            url: "hoan-thanh",
            defaults: new { controller = "GioHang", action = "HoanThanh", id = UrlParameter.Optional },
            namespaces: new[] { "OnlineShop.Controllers" }

        );
            routes.MapRoute(
          name: "Chi tiết sản phẩm",
          url: "chi-tiet-san-pham",
          defaults: new { controller = "SanPham", action = "ChiTietSP", id = UrlParameter.Optional },
          namespaces: new[] { "OnlineShop.Controllers" }

      );
            routes.MapRoute(
         name: "Trang chủ",
         url: "trang-chu",
         defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
         namespaces: new[] { "OnlineShop.Controllers" }

     );
            routes.MapRoute(
       name: "Tìm kiếm",
       url: "tim-kiem",
       defaults: new { controller = "SanPham", action = "Search", id = UrlParameter.Optional },
       namespaces: new[] { "OnlineShop.Controllers" }

   );
            routes.MapRoute(
     name: "Danh mục sản phẩm",
     url: "danh-muc-san-pham",
     defaults: new { controller = "SanPham", action = "DanhMucSanPham", id = UrlParameter.Optional },
     namespaces: new[] { "OnlineShop.Controllers" }

 );
            routes.MapRoute(
     name: "Menu",
     url: "menu",
     defaults: new { controller = "SanPham", action = "ListDMSP", id = UrlParameter.Optional },
     namespaces: new[] { "OnlineShop.Controllers" }

 );
            routes.MapRoute(
     name: "Danh sách người dùng",
     url: "nguoi-dung",
     defaults: new { controller = "Admin/User", action = "Index", id = UrlParameter.Optional },
     namespaces: new[] { "OnlineShop.Controllers" }

 );
            routes.MapRoute(
   name: "Đăng ký",
   url: "dang-ky",
   defaults: new { controller = "User", action = "DangKy", id = UrlParameter.Optional },
   namespaces: new[] { "OnlineShop.Controllers" }

);
            routes.MapRoute(
   name: "Đăng nhập",
   url: "dang-nhap",
   defaults: new { controller = "User", action = "DangNhap", id = UrlParameter.Optional },
   namespaces: new[] { "OnlineShop.Controllers" }

);
            routes.MapRoute(
 name: "Đổi Mật Khẩu",
 url: "doi-mat-khau",
 defaults: new { controller = "User", action = "DoiMatKhau", id = UrlParameter.Optional },
 namespaces: new[] { "OnlineShop.Controllers" }

);
            routes.MapRoute(
name: "Lịch sử đặt hàng",
url: "lich-su-dat-hang",
defaults: new { controller = "User", action = "TheoDoiDonHang", id = UrlParameter.Optional },
namespaces: new[] { "OnlineShop.Controllers" }

);
            routes.MapRoute(
name: "Chi Tiết Đơn Hàng",
url: "chi-tiet-don-hang",
defaults: new { controller = "User", action = "ChiTietDonHang", id = UrlParameter.Optional },
namespaces: new[] { "OnlineShop.Controllers" }

);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "OnlineShop.Controllers" }
            );
            
        }
    }
}
