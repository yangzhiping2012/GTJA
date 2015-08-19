using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTJA.MemberManage.Model.Domain;

namespace GTJA.MemberManage.Model.Map
{
    public class PortfolioMap : EntityTypeConfiguration<Portfolio>
    {
        public PortfolioMap()
        {
            this.ToTable("b_Portfolio");
            this.HasKey(c => c.ID);
            this.Property(x => x.Name).HasMaxLength(50);
            this.Property(x => x.AddTime);
            this.Property(x => x.MemberID).HasMaxLength(50);
            this.Property(x => x.State);
            this.Property(x => x.TypeID);
            this.Property(x => x.Remark).HasMaxLength(500);
        }
    }
}
