using GTJA.SystemManage.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using GTJA.SystemManage.Model.Domain;

namespace GTJA.SystemManage.Model.Mapping
{
    public class SysDictionaryMap : EntityTypeConfiguration<SysDictionary>
    {
        public SysDictionaryMap()
        {
            this.ToTable("sys_Dictionary");
            this.HasKey(c => c.ID);
            this.Property(x => x.Code).HasMaxLength(100);
            this.Property(x => x.Name).HasMaxLength(100);
            this.Property(x => x.ParentCode).HasMaxLength(100);
        }
    }
}
