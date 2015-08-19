using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GTJA.Common.Core.Encrypt;
using GTJA.Common.Interfaces;
using GTJA.MemberManage.DAL;
using GTJA.MemberManage.Model;

namespace GTJA.MemberManage.Command
{
    public class BusArticleCategoryAddCommand : IWebCommand<MemberCommandContext>
    {
        public object Execute(MemberCommandContext context)
        {
            
            var request = context.ConvertForm<ArticleCategory>();
            using (var session = MemberDbProvider.GetDbContext())
            {
                if (!string.IsNullOrEmpty(request.ID) && request.ID!="0")
                {
                    var old = session.Get<ArticleCategory>(x => x.ID == request.ID);
                    if (old != null)
                    {
                        old.Name = request.Name;
                        old.No = request.No;
                        old.OrderIndex = request.OrderIndex;
                        old.ParentID = request.ParentID;
                        old.State = request.State;
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
