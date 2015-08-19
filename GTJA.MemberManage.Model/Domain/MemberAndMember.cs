using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.Model
{
    /// <summary>
    /// 会员上下级关系
    /// </summary>
    public class MemberAndMember
    {
        /// <summary>
        /// 投资顾问上级领导ID
        /// </summary>
        public string ParentMemberID { get; set; }

        /// <summary>
        /// 下属人员ID
        /// </summary>
        public string SubMemberID { get; set; }

        /// <summary>
        /// 主键ID
        /// </summary>
        public long ID { get; set; }
    }
}
