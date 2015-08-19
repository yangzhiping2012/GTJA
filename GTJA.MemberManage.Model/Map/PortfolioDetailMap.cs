using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTJA.MemberManage.Model.Domain;

namespace GTJA.MemberManage.Model.Map
{
    public class PortfolioDetailMap : EntityTypeConfiguration<PortfolioDetail>
    {
        public PortfolioDetailMap()
        {
            this.ToTable("b_PortfolioDetail");
            this.HasKey(c => c.ID);
            this.Property(x => x.PortfolioID);
            this.Property(x => x.StockCode).HasMaxLength(50);
            this.Property(x => x.Ratio);
        }
    }
}
