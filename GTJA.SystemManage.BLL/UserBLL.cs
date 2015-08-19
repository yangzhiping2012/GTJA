using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using GTJA.Common.Core.Encrypt;
using GTJA.Common.Core.Serialize;
using GTJA.SystemManage.AppModel;
using GTJA.SystemManage.AppModel.Common;
using GTJA.SystemManage.DAL;
using GTJA.SystemManage.Model;

namespace GTJA.SystemManage.BLL
{
    public static class UserBLL
    {
        public static LoginUserModel GetLoginUser()
        {
            var cookie = HttpContext.Current.Request.Cookies["token"];
            if (cookie != null)
            {
                try
                {
                    var token = cookie.Value;
                    var str = DESEncrypt.Decrypt(token);
                    var ticket = str.FromJson<LoginUserModel>();
                    if (ticket.Expiration < DateTime.Now)
                        return null;


                    return ticket;
                }
                catch
                {

                }
            }

            return null;
        }


        public static string SysLogin(string LoginName, string Password)
        {
            if (!string.IsNullOrEmpty(LoginName) && !string.IsNullOrEmpty(Password))
            {
                using (var da = SysDbProvider.GetDbContext())
                {
                    var user = da.Get<SysUser>(x => x.LoginName == LoginName && x.State == 1);
                    if (user != null && MD5Encrypt.EncryptMD5(Password) == user.LoginPass)
                    {
                        DateTime expiration = DateTime.Now.AddMinutes(60);

                        return DESEncrypt.Encrypt(new LoginUserModel(user.ID, LoginName, expiration, true).ToJson());
                    }
                }
              
            }


            return null;
        }

        public static bool ValidModuleRight(string area, string controller, string action)
        {
            var loginUser = GetLoginUser();

            //如果是超级管理员就不做限制
            if (loginUser.UserName == "admin") return true;


            //判断权限
            var sql = @"select count(*) from sys_UserRole a ,sys_RoleModule b ,sys_Module c ,sys_Role d
                        where a.RoleID=b.RoleID
                        and b.ModuleID = c.ID
                        and a.UserID={0} and c.State=1 and d.State=1 and upper(c.Url)=upper('{1}') ";

            sql = string.Format(sql, loginUser.ID, string.Format("/{0}/{1}/{2}", area, controller, action));

            using (var session = SysDbProvider.GetDbContext())
            {
                //所有有权限的模块
                int count = session.SqlQuery<int>(sql)[0];

                return count > 0;
            }
        }
    }
}
