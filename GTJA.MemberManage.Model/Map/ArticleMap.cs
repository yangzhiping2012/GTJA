using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.Model.Map
{
    public class ArticleMap : EntityTypeConfiguration<Article>
    {
        public ArticleMap()
        {
            this.ToTable("b_Article");
            this.HasKey(c => c.ID);
            this.Property(x => x.Title).HasMaxLength(512);
            this.Property(x => x.AddTime);
            this.Property(x => x.State);
            this.Property(x => x.MemberID).HasMaxLength(128);
            this.Property(x => x.Content);
            this.Property(x => x.Recommend);
            this.Property(x => x.Top);
            this.Property(x => x.ViewCount);
            this.Property(x => x.FollowCount);
            this.Property(x => x.CommentCount);
            this.Property(x => x.FavoriteCount);
            this.Property(x => x.SupportCount);
            this.Property(x => x.PublishLevel);
            this.Property(x => x.CategoryID).HasMaxLength(50);
            this.Property(x => x.Score);
        }
    }
}
