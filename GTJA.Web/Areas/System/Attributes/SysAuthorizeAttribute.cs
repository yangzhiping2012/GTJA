using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GTJA.SystemManage.BLL;

namespace GTJA.Web.Areas.System.Attributes
{
    public class SysAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var loginUser = UserBLL.GetLoginUser();
            if (loginUser != null && loginUser.IsAdmin)
            {
                return true;
            }

            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("/System/Account/Login");
        }
    }
}