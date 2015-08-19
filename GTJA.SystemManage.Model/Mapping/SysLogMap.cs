using GTJA.SystemManage.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace GTJA.SystemManage.Model.Mapping
{
    public class SysLogMap : EntityTypeConfiguration<SysLog>
    {
        public SysLogMap()
        {
            this.ToTable("sys_Log");
            this.HasKey(c => c.ID);
            this.Property(x => x.LogType);
            this.Property(x => x.EventType);
            this.Property(x => x.ModuleName).HasMaxLength(100);
            this.Property(x => x.UserName).HasMaxLength(100);
            this.Property(x => x.IP).HasMaxLength(100);
            this.Property(x => x.CreateTime);
            this.Property(x => x.Description);
        }
    }
}
