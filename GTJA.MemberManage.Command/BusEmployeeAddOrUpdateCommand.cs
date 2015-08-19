using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTJA.Common.Core.Serialize;
using GTJA.Common.Interfaces;
using GTJA.MemberManage.AppModel.Request;
using GTJA.MemberManage.DAL;
using GTJA.MemberManage.Model;

namespace GTJA.MemberManage.Command
{
    public class BusEmployeeAddOrUpdateCommand : IWebCommand<MemberCommandContext>
    {
        public object Execute(MemberCommandContext context)
        {
            var request = context.ConvertForm<Member>();

            using (var session = MemberDbProvider.GetDbContext())
            {
                if (!string.IsNullOrEmpty(request.ID) && request.ID != "0")
                {
                    var old = session.Get<Member>(x => x.ID == request.ID);
                    if (old != null)
                    {
                        session.Update(old);
                    }
                }
                else
                {
                    var member = request.ToJson().FromJson<Member>();
                    member.AddTime = DateTime.Now;
                    member.ID = Guid.NewGuid().ToString();
                    member.MemberType = "M001";


                    session.Insert(member);
                }
                session.SaveChanges();
            }
            return true;
        }
    }
}
