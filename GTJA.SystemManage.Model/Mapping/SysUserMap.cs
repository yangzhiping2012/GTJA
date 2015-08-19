using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace GTJA.SystemManage.Model.Mapping
{
    /// <summary>
    /// 管理员用户表
    /// </summary>
    public class SysUserMap: EntityTypeConfiguration<SysUser>
    {
        public SysUserMap()
        {
            this.ToTable("sys_User");
            this.HasKey(c => c.ID);
            this.Property(x => x.LoginName).HasMaxLength(50);
            this.Property(x => x.LoginPass).HasMaxLength(100);
            this.Property(x => x.TrueName).HasMaxLength(50);
            this.Property(x => x.PoneNumber).HasMaxLength(50);
            this.Property(x => x.WorkNumber).HasMaxLength(50);
            this.Property(x => x.State);
        }
    }
}
