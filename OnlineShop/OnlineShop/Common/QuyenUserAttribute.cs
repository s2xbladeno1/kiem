using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
namespace OnlineShop.Common
{
    public class QuyenUserAttribute: AuthorizeAttribute
    {
        public string QuyenID { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (UserLogin)HttpContext.Current.Session[CommonConstant.USER_SESSION]; // Lấy thông tin user session
            if(session == null)
            {
                return false;
            }
            List<string> privilegeLevels = this.QuyenSDofUser(session.TaiKhoan);
            if (privilegeLevels.Contains(this.QuyenID) || session.GroupID == GroupUser.ADMIN_GROUP)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/Shared/Error401.cshtml"
            };
        }
        private List<string> QuyenSDofUser(string tk)
        {
            var quyen = (List<string>)HttpContext.Current.Session[CommonConstant.QUYENUSER_SESSION];
            return quyen;
        }
    }
}