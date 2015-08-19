using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTJA.Common.Interfaces;
using GTJA.MemberManage.DAL;
using GTJA.MemberManage.Model;

namespace GTJA.MemberManage.Command
{
    public class BusMemberAddOrUpdateCommand : IWebCommand<MemberCommandContext>
    {
        public object Execute(MemberCommandContext context)
        {
            var request = context.ConvertForm<Member>();

            using (var session = MemberDbProvider.GetDbContext())
            {
                if (!string.IsNullOrEmpty(request.ID) && request.ID!="0")
                {
                    var old = session.Get<Member>(x => x.ID == request.ID);
                    if (old != null)
                    {
                        session.Update(old);
                    }
                }
                else
                {
                    request.ID = Guid.NewGuid().ToString();
                    session.Insert(request);
                }
                session.SaveChanges();
            }
            return true;
        }
    }
}
