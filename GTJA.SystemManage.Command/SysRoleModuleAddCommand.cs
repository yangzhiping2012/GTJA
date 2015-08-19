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
    public class SysRoleModuleAddCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            var request = context.ConvertParam<SysRoleModuleAddRequest>();

            using (var session = SysDbProvider.GetDbContext())
            {
                //先删除现有的
                session.Delete<SysRoleModule>(x => x.RoleID == request.ID);
                foreach (long id in request.Ids.ToList())
                {
                    SysRoleModule model = new SysRoleModule();
                    model.RoleID = request.ID;
                    model.ModuleID = id;
                    session.Insert(model);
                }


                session.SaveChanges();
            }


            return true;
        }
    }
}
