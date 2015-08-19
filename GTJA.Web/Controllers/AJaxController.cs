using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTJA.Web.Controllers
{
    public class AjaxController : Controller
    {
        public ActionResult Request(string cmd,string data)
        {
           

            return new JsonResult() {Data = null};
        }
	}
}