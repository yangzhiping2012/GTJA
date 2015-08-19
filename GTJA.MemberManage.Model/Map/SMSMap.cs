using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.Model.Map
{
    public class SMSMap : EntityTypeConfiguration<SMS>
    {
        public SMSMap()
        {
            this.ToTable("b_SMS");
            this.HasKey(c => c.ID);
            this.Property(x => x.Tel).HasMaxLength(50);
            this.Property(x => x.Content).HasMaxLength(500);
            this.Property(x => x.AddTime);
            this.Property(x => x.State);
            this.Property(x => x.MemberID).HasMaxLength(50);
        }
    }
}
