using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace GTJA.SystemManage.Model.Mapping
{
    /// <summary>
    /// 管理员市州表
    /// </summary>
    public class SysRoleModuleMap : EntityTypeConfiguration<SysRoleModule>
    {
        public SysRoleModuleMap()
        {
            this.ToTable("sys_RoleModule");
            this.HasKey(c => c.ID);
            this.Property(x => x.RoleID);
            this.Property(x => x.ModuleID);
        }
    }
}
