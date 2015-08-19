using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.Model
{
    /// <summary>
    /// 积分详细
    /// </summary>
    public class ScoreDetail
    {
        public long ID { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        public string MemberID { get; set; }

        /// <summary>
        /// 获得积分
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 规则ID
        /// </summary>
        public int RuleID { get; set; }
    }
}
