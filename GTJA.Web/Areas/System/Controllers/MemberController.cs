using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTJA.Web.Areas.System.Controllers
{
    public class MemberController :  BaseController
    {
        #region 基础业务

        public ActionResult BusStationList()
        {
            return View();
        }
        /// <summary>
        /// 部门管理
        /// </summary>
        /// <returns></returns>
        public ActionResult BusDepartmentList()
        {
            return View();
        }
        /// <summary>
        /// 职位管理
        /// </summary>
        /// <returns></returns>
        public ActionResult BusEmployeeList()
        {
            return View();
        }
        /// <summary>
        /// 会员管理
        /// </summary>
        /// <returns></returns>
        public ActionResult BusMemberList()
        {
            return View();
        }
       
        /// <summary>
        /// 聊天室
        /// </summary>
        /// <returns></returns>
        public ActionResult BusChatRoomList()
        {
            return View();
        }


        #endregion
        #region 内容管理
        /// <summary>
        /// 内容分类
        /// </summary>
        /// <returns></returns>
        public ActionResult BusArticleCategoryList()
        {
            return View();
        }
        /// <summary>
        /// 内容列表
        /// </summary>
        /// <returns></returns>
        public ActionResult BusArticleList()
        {
            return View();
        }
        /// <summary>
        /// 活动列表
        /// </summary>
        /// <returns></returns>
        public ActionResult BusActivityList()
        {
            return View();
        }
        /// <summary>
        /// 评论列表
        /// </summary>
        /// <returns></returns>
        public ActionResult BusArticleCommentList()
        {
            return View();
        }
        /// <summary>
        /// 短信列表
        /// </summary>
        /// <returns></returns>
        public ActionResult BusSMSList()
        {
            return View();
        }
        #endregion

        #region 组合记录

        public ActionResult BusPortfolioChangeList()
        {
            return View();
        }
        public ActionResult BusPortfolioCommentList()
        {
            return View();
        }
        public ActionResult BusPortfolioList()
        {
            return View();
        } 
        #endregion
	}
}