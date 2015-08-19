using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using GTJA.SystemManage.Model.Domain;

namespace GTJA.SystemManage.Model.Mapping
{
    /// <summary>
    /// 管理员用户表
    /// </summary>
    public class SysSettingMap: EntityTypeConfiguration<SysSetting>
    {
        public SysSettingMap()
        {
            this.ToTable("sys_Setting");
            this.HasKey(c => c.ID);
            this.Property(x => x.Code).HasMaxLength(50);
            this.Property(x => x.Name).HasMaxLength(100);
            this.Property(x => x.Value).HasMaxLength(50);
        }
    }
}
