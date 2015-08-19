using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.Model.Map
{
    public class ArticleCategoryMap : EntityTypeConfiguration<ArticleCategory>
    {
        public ArticleCategoryMap()
        {
            this.ToTable("b_ArticleCategory");
            this.HasKey(c => c.ID);
            this.Property(x => x.Name).HasMaxLength(50);
            this.Property(x => x.No).HasMaxLength(50);
            this.Property(x => x.OrderIndex);
            this.Property(x => x.State);
            this.Property(x => x.ParentID).HasMaxLength(50);
        }
    }
}
