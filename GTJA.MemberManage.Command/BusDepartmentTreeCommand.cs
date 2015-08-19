using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTJA.Common.Data;
using GTJA.Common.Interfaces;
using GTJA.MemberManage.DAL;
using GTJA.MemberManage.Model;
using GTJA.SystemManage.AppModel;
using GTJA.SystemManage.BLL;
using GTJA.SystemManage.Model;

namespace GTJA.MemberManage.Command
{
    public class BusDepartmentTreeCommand : IWebCommand<MemberCommandContext>
    {
        public object Execute(MemberCommandContext context)
        {
            var memberId = context.RequestData;

            var list = new List<TreeModel>();
            using (var session = MemberDbProvider.GetDbContext())
            {

                var memberDepart =
                    session.All<DepartmentAndMember>()
                        .Where(x => x.MemberID == memberId)
                        .ToList()
                        .Select(x => x.DepartmentID + "#" + x.PositionNo)
                        .ToList();

                //获取所有模块
                var rootRoles = session.All<Department>()
                    .Where(x => string.IsNullOrEmpty(x.ParentID))
                    .ToList();

                rootRoles.ForEach(x =>
                {
                    var model = new TreeModel();
                    model.id = x.ID.ToString();
                    model.text = x.Name;
                    model.code = x.No;
                    //model.state = "closed";
                    GetChilds(session, model, memberDepart);
                    GetPosition(session, model, memberDepart);
                    list.Add(model);
                    
                });
            }

            return list;
        }


        private void GetChilds(IDataRepository session, TreeModel parent,List<string> list )
        {
            var childs = session.All<Department>()
                .Where(x => x.ParentID == parent.id)
                .ToList();
            childs.ForEach(x =>
            {
                var model = new TreeModel();
                model.id = x.ID.ToString();
                model.text = x.Name;
                model.code = x.No;
                //model.state = "closed";
                GetChilds(session, model, list);
                GetPosition(session, model, list);
                parent.children.Add(model);

               
            });
            
        }

        private void GetPosition(IDataRepository session, TreeModel parent, List<string> list)
        {
            var positions = DictionaryBLL.GetDictionarysByParentCode("Position");
            positions.ForEach(x =>
            {
                var model = new TreeModel();
                model.id = parent.id + "#" + x.Code;
                model.text = x.Name;
                model.code = x.Code;
                model.@checked = list.Contains(model.id);
                parent.children.Add(model);
            });
        }
    }
}
