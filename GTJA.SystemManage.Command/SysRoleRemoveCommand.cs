using GTJA.Common.Interfaces;
using GTJA.SystemManage.DAL;
using GTJA.SystemManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.SystemManage.Command
{
    public class SysRoleRemoveCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            long[] ids = context.ConvertParam<long[]>();

            using (var session = SysDbProvider.GetDbContext())
            {
                foreach (var id in ids)
                {
                    var role = session.Get<SysRole>(x=>x.ID == id);
                    role.State = 2;
                    session.Update<SysRole>(role);

                }

                session.SaveChanges();
            }
            return true;
        }
    }
}
