using GTJA.Common.Interfaces;
using GTJA.SystemManage.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using GTJA.SystemManage.Model;

namespace GTJA.SystemManage.Command
{
    public class SysRoleListCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            int rows = Convert.ToInt32(HttpContext.Current.Request["rows"]);
            int page = Convert.ToInt32(HttpContext.Current.Request["page"]);
            using (var session = SysDbProvider.GetDbContext())
            {
                int total = 0;
                var list = session.Find<SysRole,long>(null,s => s.ID, rows, page, out total);

                session.SaveChanges();
                return new { total = total, rows = list };
            }

        }
    }
}
