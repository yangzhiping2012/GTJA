using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.Model
{
    /// <summary>
    /// 会员互相关注表
    /// </summary>
    public class MemberFollow
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        public string MemberID { get; set; }

        /// <summary>
        /// 被关注会员ID
        /// </summary>
        public string FollowMemberID { get; set; }

        /// <summary>
        /// 关注时间
        /// </summary>
        public int AddTime { get; set; }
    }
}
