using GTJA.Common.Interfaces;
using GTJA.SystemManage.DAL;
using GTJA.SystemManage.Model;
using GTJA.SystemManage.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.SystemManage.Command
{
    public class SysRoleAddCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            var request = context.ConvertForm<SysRole>();

            using (var session = SysDbProvider.GetDbContext())
            {
                if (request.ID == 0)
                {
                    session.Insert(request);
                }
                else
                {
                    SysRole role = session.Get<SysRole>(x => x.ID == request.ID);
                    role.Remark = request.Remark;
                    role.RoleName = request.RoleName;
                    role.State = request.State;

                    session.Update<SysRole>(role);
                }

                session.SaveChanges();
            }
               
            return true;
        }
    }
}
