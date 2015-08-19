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
    public class SysUserRoleMap : EntityTypeConfiguration<SysUserRole>
    {
        public SysUserRoleMap()
        {
            this.ToTable("sys_UserRole");
            this.HasKey(c => c.ID);
            this.Property(c => c.RoleID);
            this.Property(c => c.UserID);
        }
    }
}
