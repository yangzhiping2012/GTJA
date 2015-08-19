using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.Model.Domain
{
    /// <summary>
    /// 投资组合
    /// </summary>
    public class Portfolio
    {
        public long ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        public string MemberID { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 组合类型
        /// </summary>
        public int TypeID { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }
    }
}
