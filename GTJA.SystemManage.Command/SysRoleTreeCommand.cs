using GTJA.Common.Interfaces;
using GTJA.SystemManage.AppModel;
using GTJA.SystemManage.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTJA.SystemManage.Model;
using GTJA.SystemManage.Model.Domain;

namespace GTJA.SystemManage.Command
{
    public class SysRoleTreeCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            //用户ID
            long userID = Convert.ToInt64(context.RequestData);
            var list = new List<TreeModel>();
            using (var session = SysDbProvider.GetDbContext())
            {
                //获取所有角色
                var roles = session.All<SysRole>().ToList();

                //获取用户的角色
                var userRoles = session.All<SysUserRole>().Where(x => x.UserID == userID).Select(x => x.RoleID).ToList<long>();

                var child = new TreeModel() { text="所有角色"};
                list.Add(child);

                roles.ForEach(x =>
                {
                    var model = new TreeModel();
                    model.id = x.ID.ToString();
                    model.text = x.RoleName;
                    model.@checked = userRoles.Contains(x.ID);
                    child.children.Add(model);
                });
            }

            return list;
        }
    }
}
