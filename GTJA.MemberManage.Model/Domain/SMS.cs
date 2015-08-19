using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.Model
{
    /// <summary>
    /// 短信表：用于记录调仓信息
    /// </summary>
    public class SMS
    {
        public long ID { get; set; }

        /// <summary>
        /// 会员电话号码
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 短信内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 对应会员ID
        /// </summary>
        public string MemberID { get; set; }

        /// <summary>
        /// 通知类型
        /// </summary>
        public int TypeID { get; set; }
    }
}
