using GTJA.Common.Data;
using GTJA.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using GTJA.SystemManage.AppModel;
using GTJA.SystemManage.DAL;
using GTJA.SystemManage.Model;
using GTJA.SystemManage.Model.Domain;

namespace GTJA.SystemManage.Command
{
    public class SysModuleListCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            var list = new List<ModuleModel>();
            using (var session = SysDbProvider.GetDbContext())
            {
                var roots = session.All<SysModule>()
                    .Where(x => string.IsNullOrEmpty(x.ParentCode) )
                    .ToList();

                roots.ForEach(x =>
                {
                    var model = new ModuleModel();
                    model.ModuleName = x.ModuleName;
                    model.Url = x.Url;
                    model.ID = x.ID;
                    model.State = x.State;
                    model.ModuleCode = x.ModuleCode;
                    GetChilds(session, model);
                    list.Add(model);
                });

                session.SaveChanges();
            }


            return list;
        }

        private void GetChilds(IDataRepository session, ModuleModel parent)
        {
            var childs = session.All<SysModule>()
                .Where(x => x.ParentCode == parent.ModuleCode )
                .ToList();
            if (childs.Count > 0)
            {
                childs.ForEach(x =>
                {
                    var model = new ModuleModel();
                    model.ModuleName = x.ModuleName;
                    model.Url = x.Url;
                    model.ID = x.ID;
                    model.State = x.State;
                    model.ModuleCode = x.ModuleCode;
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
