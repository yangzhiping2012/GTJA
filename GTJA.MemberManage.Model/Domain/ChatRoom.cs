using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.Model
{
    /// <summary>
    /// 聊天室
    /// </summary>
    public class ChatRoom
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 频道号
        /// </summary>
        public string ChannelNo { get; set; }

        /// <summary>
        /// 频道密码
        /// </summary>
        public string ChannelPassword { get; set; }

        /// <summary>
        /// 投资顾问ID，外键关联Member表
        /// </summary>
        public string MemberID { get; set; }

        /// <summary>
        /// 聊天室名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 级别：对应相应的会员
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 所需积分
        /// </summary>
        public int Score { get; set; }
    }
}
