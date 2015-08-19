using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.Model
{
    /// <summary>
    /// 活动报名表
    /// </summary>
    public class ActivityMember
    {
        public long ActivityID { get; set; }

        public string MemberID { get; set; }

        public DateTime AddTime { get; set; }

        public long ID { get; set; }
    }
}
