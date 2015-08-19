using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.Model.Map
{
    public class ScoreDetailMap : EntityTypeConfiguration<ScoreDetail>
    {
        public ScoreDetailMap()
        {
            this.ToTable("b_ScoreDetail");
            this.HasKey(c => c.ID);
            this.Property(x => x.MemberID).HasMaxLength(50);
            this.Property(x => x.Score);
            this.Property(x => x.AddTime);
            this.Property(x => x.RuleID);

        }
    }
}
