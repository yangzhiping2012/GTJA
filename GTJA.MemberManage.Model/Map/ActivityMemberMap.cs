using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.Model.Map
{
    public class ActivityMemberMap : EntityTypeConfiguration<ActivityMember>
    {
        public ActivityMemberMap()
        {
            this.ToTable("b_ActivityMember");
            this.HasKey(c => c.ID);
            this.Property(x => x.ActivityID);
            this.Property(x => x.MemberID).HasMaxLength(128);
            this.Property(x => x.AddTime);
        }
    }
}
