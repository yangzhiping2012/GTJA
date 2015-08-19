using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTJA.Web.Areas.System.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /System/Home/

        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Main()
        {
            return View();
        }
        #region 系统管理
        /// <summary>
        /// 系统设置
        /// </summary>
        /// <returns></returns>
        public ActionResult SysSettingList()
        {
            return View();
        }
       
        /// <summary>
        /// 菜单管理
        /// </summary>
        /// <returns></returns>
        public ActionResult SysModuleList()
        {
            return View();
        }

        /// <summary>
        /// 日志管理
        /// </summary>
        /// <returns></returns>
        public ActionResult SysLogList()
        {
            return View();
        }

        /// <summary>
        /// 字典管理
        /// </summary>
        /// <returns></returns>
        public ActionResult SysDictionaryList()
        {
            return View();
        } 
        #endregion


        #region 用户设置
        /// <summary>
        /// 用户管理
        /// </summary>
        /// <returns></returns>
        public ActionResult SysUserList()
        {
            return View();
        }

        /// <summary>
        /// 角色管理
        /// </summary>
        /// <returns></returns>
        public ActionResult SysRoleList()
        {
            return View();
        }
        /// <summary>
        /// 权限管理
        /// </summary>
        /// <returns></returns>
        public ActionResult SysPermissionList()
        {
            return View();
        }
        #endregion
       
    }
}
