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
    public class SysRoleMap : EntityTypeConfiguration<SysRole>
    {
        public SysRoleMap()
        {
            this.ToTable("sys_Role");
            this.HasKey(c => c.ID);
            this.Property(x => x.RoleName).HasMaxLength(100);
            this.Property(x => x.State);
            this.Property(x => x.Remark).HasMaxLength(500);
        }
    }
}
