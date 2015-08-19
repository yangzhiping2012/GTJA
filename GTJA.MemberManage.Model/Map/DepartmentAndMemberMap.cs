using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.Model.Map
{
    public class DepartmentAndMemberMap : EntityTypeConfiguration<DepartmentAndMember>
    {
        public DepartmentAndMemberMap()
        {
            this.ToTable("b_DepartmentAndMember");
            this.HasKey(c => c.ID);
            this.Property(x => x.DepartmentID).HasMaxLength(50);
            this.Property(x => x.MemberID).HasMaxLength(50);
            this.Property(x => x.PositionNo).HasMaxLength(50);
        }
    }
}
