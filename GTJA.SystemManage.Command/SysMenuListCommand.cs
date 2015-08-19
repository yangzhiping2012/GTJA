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
    /// <summary>
    /// 获取菜单
    /// </summary>
    public class SysMenuListCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            var list = new List<SysMenuModel>();
            string sql;
            if(context.CurrentUser.UserName.ToLower() =="admin")
            {
                sql = "select * from sys_Module where ParentCode is not null and ParentCode!='' and State=1";
            }
            else
            {
                sql = @"select distinct c.* from sys_UserRole a ,sys_RoleModule b ,sys_Module c ,sys_Role d
                        where a.RoleID=b.RoleID
                        and b.ModuleID = c.ID
                        and a.UserID={0} and c.State=1 and d.State=1 ";
                sql = string.Format(sql, context.CurrentUser.ID);
            }

            using(var session = SysDbProvider.GetDbContext())
            {
                //所有有权限的模块
                var modules = session.SqlQuery<SysModule>(sql);

                //获取顶级模块ID
                var parentIds = modules.Select(x => x.ParentCode).Distinct().ToList();

                parentIds.ForEach(x =>
                {
                    SysModule module =session.Get<SysModule>(y=>y.ModuleCode == x);

                    var menu = new SysMenuModel();
                    menu.text = module.ModuleName;
                    menu.url = module.Url;

                    //子菜单
                    var childModules = modules.Where(y => y.ParentCode == x).ToList();
                    childModules.ForEach(z =>
                    {
                        var childMenu = new SysMenuModel();
                        childMenu.text = z.ModuleName;
                        childMenu.url = z.Url;
                        childMenu.iconCls = "icons-application-application_go";
                        menu.menus.Add(childMenu);
                    });

                    list.Add(menu);

                });
            }

            return list;
        }
    }
}
