using GTJA.Common.Interfaces;
using GTJA.MemberManage.DAL;
using GTJA.MemberManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.Command
{
    public class BusStaionRemoveCommand : IWebCommand<MemberCommandContext>
    {

        public object Execute(MemberCommandContext context)
        {
            string[] ids = context.ConvertParam<string[]>();

            using (var session = MemberDbProvider.GetDbContext())
            {
                foreach (var id in ids)
                {
                    var model = session.Get<Station>(x => x.ID == id);
                    session.Delete(model);
                }

                session.SaveChanges();
            }
            return true;
        }
    }
}
