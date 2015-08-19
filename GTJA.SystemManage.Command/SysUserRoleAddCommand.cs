using GTJA.Common.Interfaces;
using GTJA.SystemManage.AppModel.Request;
using GTJA.SystemManage.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTJA.SystemManage.Model;

namespace GTJA.SystemManage.Command
{
    public class SysUserRoleAddCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            var request = context.ConvertParam<SysUserRoleAddRequest>();

            using(var session = SysDbProvider.GetDbContext())
            {
               var deletes = session.Find<SysUserRole>(x => x.UserID == request.ID);
                foreach (var sysUserRole in deletes)
                {
                    session.Delete(sysUserRole);
                }
              
                foreach (long id in request.Ids.ToList())
                {
                    SysUserRole model = new SysUserRole();
                    model.UserID = request.ID;
                    model.RoleID = id;
                    session.Insert(model);

                    
                }

                session.SaveChanges();
            }


            return true;
        }
    }
}
