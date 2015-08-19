using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTJA.Common.Data;
using GTJA.Common.Interfaces;
using GTJA.MemberManage.AppModel.Request;
using GTJA.MemberManage.DAL;
using GTJA.MemberManage.Model;

namespace GTJA.MemberManage.Command
{
    public class BusEmployeeListCommand : IWebCommand<MemberCommandContext>
    {
        public object Execute(MemberCommandContext context)
        {
            var request = context.ConvertForm<BusMemberListRequest>();
            using (var session = MemberDbProvider.GetDbContext())
            {
                int total = 0;

                var query = session.All<Member>().Where(x=>x.MemberType=="M001");


                var list = query.Search<Member, string>(x => x.ID, request.rows, request.page, out total);


                return new { total = total, rows = list };
            }
        }
    }
}
