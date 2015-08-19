using GTJA.Common.Interfaces;
using GTJA.Common.Data;
using GTJA.SystemManage.AppModel.Request;
using GTJA.SystemManage.DAL;
using GTJA.SystemManage.Model;
using GTJA.SystemManage.Model.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;


namespace GTJA.SystemManage.Command
{
    public class SysUserListCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            var request = context.ConvertForm<SysUserListRequest>();

            using (var session = SysDbProvider.GetDbContext())
            {
                int total = 0;

                var query = session.All<SysUser>();

                if (!string.IsNullOrEmpty(request.KeyWords))
                {
                    query = query.Where(x => x.LoginName.Contains(request.KeyWords)
                                 || x.TrueName.Contains(request.KeyWords));
                }

                query = query.Where(x => x.ID != 1);

                var list = query.Search<SysUser,long>(x=>x.ID, request.rows, request.page, out total);

                session.SaveChanges();
                return new { total = total, rows = list };
            }

        }
    }
}
