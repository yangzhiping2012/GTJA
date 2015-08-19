using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.Model.Map
{
    public class MemberAuthMap : EntityTypeConfiguration<MemberAuth>
    {
        public MemberAuthMap()
        {
            this.ToTable("b_MemberAuth");
            this.HasKey(c => c.ID);
            this.Property(x => x.AuthType);
            this.Property(x => x.ValidCode).HasMaxLength(50);
            this.Property(x => x.ExpiredTime);
            this.Property(x => x.AuthIdentity).HasMaxLength(50);
        }
    }
}
