using System.Reflection;
using GTJA.Common.Data;
using GTJA.Common.Interfaces;
using GTJA.SystemManage.AppModel;
using GTJA.SystemManage.DAL;
using GTJA.SystemManage.Model;
using GTJA.SystemManage.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.SystemManage.Command
{
    public class SysModuleTreeCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            //用户ID
            long roleID = Convert.ToInt64(context.RequestData);
            var list = new List<TreeModel>();
            using (var session = SysDbProvider.GetDbContext())
            {
                //获取所有模块
                var rootRoles = session.All<SysModule>()
                    .Where(x=> string.IsNullOrEmpty(x.ParentCode) )
                    .ToList();

                //获取角色拥有的模块
                var roleModules = session.All<SysRoleModule>()
                    .Where(x => x.RoleID == roleID).Select(x => x.ModuleID)
                    .ToList<long>();

                rootRoles.ForEach(x =>
                {
                    var model = new TreeModel();
                    model.id = x.ID.ToString();
                    model.text = x.ModuleName;
                    model.code = x.ModuleCode;
                    model.@checked = roleModules.Contains(x.ID);
                    GetChilds(session, model, roleModules);
                    list.Add(model);
                });
            }

            return list;
        }

        private void GetChilds(IDataRepository session, TreeModel parent, List<long> roleModules)
        {
            var childs = session.All<SysModule>()
                .Where(x => x.ParentCode == parent.code )
                .ToList();
            childs.ForEach(x =>
            {
                var model = new TreeModel();
                model.id = x.ID.ToString();
                model.text = x.ModuleName;
                model.code = x.ModuleCode;
                model.@checked = roleModules.Contains(x.ID);
                GetChilds(session, model, roleModules);
                parent.children.Add(model);
            });
        }
    }
}
