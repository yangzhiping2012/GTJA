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
    public class SysModuleMap : EntityTypeConfiguration<SysModule>
    {
        public SysModuleMap()
        {
            this.ToTable("sys_Module");
            this.HasKey(c => c.ID);
            this.Property(x => x.ModuleName).HasMaxLength(100);
            this.Property(x => x.ParentCode).HasMaxLength(100); ;
            this.Property(x => x.Url).HasMaxLength(100);
            this.Property(x => x.Remark).HasMaxLength(500);
            this.Property(x => x.State);
            this.Property(x => x.ModuleCode).HasMaxLength(100);
        }
    }
}
