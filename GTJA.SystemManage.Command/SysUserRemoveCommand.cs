using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTJA.Common.Interfaces;
using GTJA.SystemManage.DAL;
using GTJA.SystemManage.Model;

namespace GTJA.SystemManage.Command
{
    public class SysUserRemoveCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            long[] ids = context.ConvertParam<long[]>();

            using (var session = SysDbProvider.GetDbContext())
            {
                foreach (var id in ids)
                {
                    var sysUser = session.Get<SysUser>(x=>x.ID == id);
                    sysUser.State = 2;
                    session.Update<SysUser>(sysUser);


                }

                session.SaveChanges();
            }
            return true;
        }
    }
}
