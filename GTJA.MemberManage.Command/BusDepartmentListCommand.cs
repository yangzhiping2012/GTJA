using GTJA.Common.Data;
using GTJA.Common.Interfaces;
using GTJA.MemberManage.AppModel.Response;
using GTJA.MemberManage.DAL;
using GTJA.MemberManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.Command
{
    public class BusDepartmentListCommand : IWebCommand<MemberCommandContext>
    {

        public object Execute(MemberCommandContext context)
        {
            var list = new List<DepartmentModel>();
            using (var session = MemberDbProvider.GetDbContext())
            {
                var roots = session.All<Department>()
                    .Where(x => string.IsNullOrEmpty(x.ParentID))
                    .ToList();

                roots.ForEach(x =>
                {
                    var model = new DepartmentModel();
                    model.ID = x.ID;
                    model.No = x.No;
                    model.Name = x.Name;
                    model.ParentID = x.ParentID;
                    model.Remark = x.Remark;
                    model.State = x.State;
                    GetChilds(session, model);
                    list.Add(model);
                });

                session.SaveChanges();
            }


            return list;
        }


        private void GetChilds(IDataRepository session, DepartmentModel parent)
        {
            var childs = session.All<Department>()
                .Where(x => x.ParentID == parent.ID)
                .ToList();
            if (childs.Count > 0)
            {
                childs.ForEach(x =>
                {
                    var model = new DepartmentModel();
                    model.ID = x.ID;
                    model.No = x.No;
                    model.Name = x.Name;
                    model.ParentID = x.ParentID;
                    model.Remark = x.Remark;
                    model.State = x.State;
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
