using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTJA.Common.Data;
using GTJA.Common.Interfaces;
using GTJA.MemberManage.AppModel.Request;
using GTJA.MemberManage.DAL;
using GTJA.MemberManage.Model.Domain;

namespace GTJA.MemberManage.Command
{
    class BusPortfolioChangeListCommand : IWebCommand<MemberCommandContext>
    {
        public object Execute(MemberCommandContext context)
        {
            var request = context.ConvertForm<PageInfo>();
            using (var session = MemberDbProvider.GetDbContext())
            {
                var query = session.All<PortfolioChange>();


                int total;

                var list = query.Search<PortfolioChange, long>(x => x.ID, request.rows, request.page, out total);

                return new { total = total, rows = list };
            }
        }
    }
}
