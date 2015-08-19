using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GTJA.SystemManage.Command;
using GTJA.Web.Areas.System.Attributes;

namespace GTJA.Web.Areas.System.Controllers
{
    [SysAuthorize]
    public class AjaxController : Controller
    {

        public ActionResult Request(string cmd, string data)
        {
            var command = SysCommandManager.GetWebCommand(cmd);
            var result = command.Execute(new SysCommandContext(data));

            return new JsonResult() { Data = result, ContentType = "text/html", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
	}
}