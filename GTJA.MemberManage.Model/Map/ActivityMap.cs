using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.Model.Map
{
    public class ActivityMap : EntityTypeConfiguration<Activity>
    {
        public ActivityMap()
        {
            this.ToTable("b_Activity");
            this.HasKey(c => c.ID);
            this.Property(x => x.AddTime);
            this.Property(x => x.Content);
            this.Property(x => x.SysUserID).HasMaxLength(100);
            this.Property(x => x.Score);
            this.Property(x => x.State);
            this.Property(x => x.Title).HasMaxLength(500);
        }
    }
}
