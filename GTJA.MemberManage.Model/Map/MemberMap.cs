using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.Model.Map
{
    public class MemberMap : EntityTypeConfiguration<Member>
    {
        public MemberMap()
        {
            this.ToTable("b_Member");
            this.HasKey(c => c.ID);
            this.Property(x => x.NickName).HasMaxLength(50);
            this.Property(x => x.Tel).HasMaxLength(50);
            this.Property(x => x.RealName).HasMaxLength(50);
            this.Property(x => x.Password).HasMaxLength(50);
            this.Property(x => x.AddTime);
            this.Property(x => x.MemberType).HasMaxLength(50);
            this.Property(x => x.Email).HasMaxLength(50);
            this.Property(x => x.Address).HasMaxLength(500);
            this.Property(x => x.Asset);
            this.Property(x => x.Score);
            this.Property(x => x.Sex);
            this.Property(x => x.Age);
            this.Property(x => x.IDCard).HasMaxLength(50);
            this.Property(x => x.State);
            this.Property(x => x.StationID).HasMaxLength(50);

            this.Property(x => x.Profile);
            this.Property(x => x.FundAccount);
            this.Property(x => x.OpeningDate);
            this.Property(x => x.MarketingPerson).HasMaxLength(50);
            this.Property(x => x.AssetOfMonth);
            this.Property(x => x.NetCommission);
        }
    }
}
