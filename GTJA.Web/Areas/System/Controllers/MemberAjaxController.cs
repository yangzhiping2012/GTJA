using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GTJA.SystemManage.Command;
using GTJA.MemberManage.Command;
using GTJA.Web.Areas.System.Attributes;

namespace GTJA.Web.Areas.System.Controllers
{

    [RouteArea("Member")]
    [RoutePrefix("Ajax")]
    [Route("{action}")]
    [SysAuthorize]
    public class MemberAjaxController : Controller
    {

        public  ActionResult  Request(string cmd, string data)
        {
            var command = MemberCommandManager.GetWebCommand(cmd);
            var result = command.Execute(new MemberCommandContext(data));

            return new JsonResult() { Data = result, ContentType = "text/html", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
	}
}