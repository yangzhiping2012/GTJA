using GTJA.Common.Interfaces;
using GTJA.SystemManage.AppModel.Request;
using GTJA.SystemManage.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTJA.SystemManage.Model;
using GTJA.SystemManage.Model.Domain;
using GTJA.Common.Data;
namespace GTJA.SystemManage.Command
{
    public class SysLogListCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            var request = context.ConvertForm<SysLogListRequest>();
            using (var session = SysDbProvider.GetDbContext())
            {
                var query = session.All<SysLog>();
                if (request.LogType.HasValue)
                {
                    query = query.Where(x => x.LogType == request.LogType.Value);
                }
                if (request.EventType.HasValue)
                {
                    query = query.Where(x => x.EventType == request.EventType.Value);
                }
                if (request.StartTime.HasValue)
                {
                    query = query.Where(x => x.CreateTime >= request.StartTime.Value);
                }
                if (request.EndTime.HasValue)
                {
                    query = query.Where(x => x.CreateTime <= request.EndTime.Value);
                }
                if (!string.IsNullOrEmpty(request.KeyWords))
                {
                    query = query.Where(x => x.ModuleName.Contains(request.KeyWords) || x.UserName.Contains(request.KeyWords));
                }

                int total;

                var list = query.Search<SysLog,long>(x=>x.ID, request.rows, request.page, out total);

                return new { total = total, rows = list };
            }

        }
    }
}
