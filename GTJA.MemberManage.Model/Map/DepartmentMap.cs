using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.Model.Map
{
    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            this.ToTable("b_Department");
            this.HasKey(c => c.ID);
            this.Property(x => x.No).HasMaxLength(50);
            this.Property(x => x.Name).HasMaxLength(50);
            this.Property(x => x.ParentID).HasMaxLength(50);
            this.Property(x => x.Remark).HasMaxLength(500);
            this.Property(x => x.State);
           
        }
    }
}
