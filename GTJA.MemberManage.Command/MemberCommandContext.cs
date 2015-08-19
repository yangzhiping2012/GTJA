using GTJA.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using GTJA.Common.Core.Serialize;
using GTJA.SystemManage.AppModel.Common;
using GTJA.SystemManage.BLL;

namespace GTJA.MemberManage.Command
{
    public class MemberCommandContext : IWebCommandContext
    {
      
        #region 变量

        private LoginUserModel currentUser; 
        #endregion

        #region 构造函数

        public MemberCommandContext(string requestData)
        {
            RequestData = requestData;
        } 
        #endregion

        #region 属性

        public string RequestData { get; set; }

        public LoginUserModel CurrentUser
        {
            get
            {
                if (currentUser == null)
                    currentUser = UserBLL.GetLoginUser();

                return currentUser;
            }
        } 
        #endregion

        #region 方法

        public T ConvertForm<T>() where T : class
        {
            string json = "";
            var forms = HttpContext.Current.Request.Form;
            foreach (var key in forms.AllKeys)
            {
                if (json.Length > 0) json += ",";
                json += string.Format("'{0}':'{1}'", key, forms[key]);
            }
            json = "{" + json + "}";

            return json.FromJson<T>();
        }

        public T ConvertParam<T>() 
        {
            return RequestData.FromJson<T>();
        } 
        #endregion


    }
}
