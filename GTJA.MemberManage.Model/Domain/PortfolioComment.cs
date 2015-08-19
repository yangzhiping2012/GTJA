using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.Model.Domain
{
    /// <summary>
    /// 评论
    /// </summary>
    public class PortfolioComment
    {
        public long ID { get; set; }

        /// <summary>
        /// 组合ID
        /// </summary>
        public long PortfolioID { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        public string MemberID { get; set; }

        public int State { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}
