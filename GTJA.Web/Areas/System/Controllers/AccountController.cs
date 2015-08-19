using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GTJA.Common.Core.Encrypt;
using GTJA.Common.Core.Serialize;
using GTJA.SystemManage.AppModel.Common;
using GTJA.SystemManage.BLL;

namespace GTJA.Web.Areas.System.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string LoginName, string realName, string Password, string returnUrl)
        {
            LoginName = HttpUtility.UrlDecode(LoginName);
            string token = UserBLL.SysLogin(LoginName,Password);
            bool state = !string.IsNullOrEmpty(token);

            var response = new { state = state, token = token };

            return new JsonResult()
            {
                Data = response,
                ContentType = "text/html",
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
