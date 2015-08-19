using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTJA.Common.Data;
using GTJA.Common.Interfaces;
using GTJA.MemberManage.AppModel.Response;
using GTJA.MemberManage.DAL;
using GTJA.MemberManage.Model;
using GTJA.SystemManage.AppModel;
using GTJA.SystemManage.Model;

namespace GTJA.MemberManage.Command
{
    public class BusArticleCategoryListCommand : IWebCommand<MemberCommandContext>
    {
        public object Execute(MemberCommandContext context)
        {
            var list = new List<ArticleCategoryModel>();
            using (var session = MemberDbProvider.GetDbContext())
            {
                var roots = session.All<ArticleCategory>()
                    .Where(x => string.IsNullOrEmpty(x.ParentID))
                    .ToList();

                roots.ForEach(x =>
                {
                    var model = new ArticleCategoryModel();
                    model.Name = x.Name;
                    model.No = x.No;
                    model.ID = x.ID;
                    model.State = x.State;
                    model.ParentID = x.ParentID;
                    model.OrderIndex = x.OrderIndex;
                    GetChilds(session, model);
                    list.Add(model);
                });

                session.SaveChanges();
            }


            return list;
        }

        private void GetChilds(IDataRepository session, ArticleCategoryModel parent)
        {
            var childs = session.All<ArticleCategory>()
                .Where(x => x.ParentID == parent.ID)
                .ToList();
            if (childs.Count > 0)
            {
                childs.ForEach(x =>
                {
                    var model = new ArticleCategoryModel();
                    model.Name = x.Name;
                    model.No = x.No;
                    model.ID = x.ID;
                    model.State = x.State;
                    model.ParentID = x.ParentID;
                    model.OrderIndex = x.OrderIndex;
                    GetChilds(session, model);
                    parent.children.Add(model);
                });
            }
            else
            {
                parent.state = "open";
            }
        }
    }
}
