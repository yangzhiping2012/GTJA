using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.Model.Map
{
    public class ChatRoomMap : EntityTypeConfiguration<ChatRoom>
    {
        public ChatRoomMap()
        {
            this.ToTable("b_ChatRoom");
            this.HasKey(c => c.ID);
            this.Property(x => x.ChannelNo).HasMaxLength(50);
            this.Property(x => x.ChannelPassword).HasMaxLength(50);
            this.Property(x => x.MemberID).HasMaxLength(50);
            this.Property(x => x.Name).HasMaxLength(50);
            this.Property(x => x.State);
            this.Property(x => x.AddTime);
            this.Property(x => x.Level);
            this.Property(x => x.Remark).HasMaxLength(500);
            this.Property(x => x.Score);
        }
    }
}
