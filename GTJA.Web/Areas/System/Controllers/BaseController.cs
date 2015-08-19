using GTJA.Web.Areas.System.Attributes;
using GTJA.SystemManage.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTJA.Web.Areas.System.Controllers
{
    [SysAuthorize]
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"].ToString();
            var action = filterContext.RouteData.Values["action"].ToString();
            var area = filterContext.RouteData.DataTokens["area"] == null ? "" : filterContext.RouteData.DataTokens["area"].ToString();
            
            // area/controller/action
            if (!UserBLL.ValidModuleRight(area, controller, action))
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult()
                    {
                        Data =  "权限不足",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    filterContext.Result = new RedirectResult("/System/Home/Error");
                }
            }

            base.OnActionExecuting(filterContext);
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            try
            {
                var controller = filterContext.RouteData.Values["controller"].ToString();
                var action = filterContext.RouteData.Values["action"].ToString();
                var area = filterContext.RouteData.DataTokens["area"] == null ? "" : filterContext.RouteData.DataTokens["area"].ToString();

                var msg = string.Format("[{0}-{1}-{2}]\r\n", area, controller, action);

                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult()
                    {
                        Data = "filterContext.Exception.Message",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                    filterContext.ExceptionHandled = true;
                }
                else
                {
                    base.OnException(filterContext);
                }
            }
            catch
            {
                
               
            }
            
        }

    }
}
