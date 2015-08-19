using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTJA.Common.Core.Encrypt;
using GTJA.Common.Data;
using GTJA.Common.Interfaces;
using GTJA.SystemManage.DAL;
using GTJA.SystemManage.Model;
using GTJA.SystemManage.Model.Domain;

namespace GTJA.SystemManage.Command
{
    public class SysUserAddCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            //请求数据
            var request = context.ConvertForm<SysUser>();

            using (var session = SysDbProvider.GetDbContext())
            {
                if (request.ID == 0)
                {
                    //判断名称是否重复
                    if (IsExists(session, request.LoginName))
                    {
                        return "Exists";
                    }

                    //密码默认和登录用户名一致
                    request.LoginPass = MD5Encrypt.EncryptMD5(request.LoginName);
                    session.Insert(request);

                }
                else
                {
                    var user = session.Get<SysUser>(x=>x.ID == request.ID);
                    if (!string.IsNullOrEmpty(request.LoginPass))
                    {
                        user.LoginPass = MD5Encrypt.EncryptMD5(request.LoginPass);
                    }
                    else
                    {
                        user.State = request.State;
                        user.TrueName = request.TrueName;
                        user.WorkNumber = request.WorkNumber;
                        user.PoneNumber = request.PoneNumber;
                    }

                    session.Update(user);

                }

                session.SaveChanges();
            }
            return true;
        }

        private bool IsExists(IDataRepository session, string loginName)
        {
            return session.All<SysUser>().FirstOrDefault(x => x.LoginName == loginName) != null;
        }
    }
}
