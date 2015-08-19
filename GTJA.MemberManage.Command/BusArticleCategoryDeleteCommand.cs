using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTJA.Common.Interfaces;
using GTJA.MemberManage.DAL;
using GTJA.MemberManage.Model;
using GTJA.SystemManage.Model;

namespace GTJA.MemberManage.Command
{
    public class BusArticleCategoryDeleteCommand : IWebCommand<MemberCommandContext>
    {
        public object Execute(MemberCommandContext context)
        {
            string[] ids = context.ConvertParam<string[]>();

            using (var session = MemberDbProvider.GetDbContext())
            {
                foreach (var id in ids)
                {
                    var model = session.Get<ArticleCategory>(x => x.ID == id);

                    if (session.Get<ArticleCategory>(x => x.ParentID == model.ID) == null)
                    {
                        session.Delete(model);
                    }
                   
                }

                session.SaveChanges();
            }
            return true;
        }
    }
}
