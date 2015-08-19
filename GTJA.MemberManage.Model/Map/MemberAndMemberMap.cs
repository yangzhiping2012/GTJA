using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.Model.Map
{
    public class MemberAndMemberMap : EntityTypeConfiguration<MemberAndMember>
    {
        public MemberAndMemberMap()
        {
            this.ToTable("b_MemberAndMember");
            this.HasKey(c => c.ID);
            this.Property(x => x.ParentMemberID).HasMaxLength(50);
            this.Property(x => x.SubMemberID).HasMaxLength(50);
        }
    }
}
