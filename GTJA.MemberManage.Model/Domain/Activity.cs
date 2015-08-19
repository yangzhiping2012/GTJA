using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.Model
{
    /// <summary>
    /// 活动信息表
    /// </summary>
    public class Activity
    {
        public long ID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 活动内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public string SysUserID { get; set; }

        /// <summary>
        /// 获得多少积分
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
    }
}
