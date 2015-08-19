using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTJA.MemberManage.Model.Domain;

namespace GTJA.MemberManage.Model.Map
{
    public class PortfolioCommentMap : EntityTypeConfiguration<PortfolioComment>
    {
        public PortfolioCommentMap()
        {
            this.ToTable("b_PortfolioComment");
            this.HasKey(c => c.ID);
            this.Property(x => x.PortfolioID);
            this.Property(x => x.Content).HasMaxLength(500);
            this.Property(x => x.MemberID).HasMaxLength(50);
            this.Property(x => x.State);
            this.Property(x => x.AddTime);
        }
    }
}
