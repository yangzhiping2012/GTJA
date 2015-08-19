using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.Model.Map
{
    public class ArticleCommentMap : EntityTypeConfiguration<ArticleComment>
    {
        public ArticleCommentMap()
        {
            this.ToTable("b_ArticleComment");
            this.HasKey(c => c.ID);
            this.Property(x => x.ArticleID);
            this.Property(x => x.MemberID).HasMaxLength(50);
            this.Property(x => x.Content).HasMaxLength(1000);
            this.Property(x => x.AddTime);
            this.Property(x => x.State);
        }
    }
}
