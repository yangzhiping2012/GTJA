using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.Model
{
    /// <summary>
    /// 部门关联人
    /// </summary>
    public class DepartmentAndMember
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        public string DepartmentID { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        public string MemberID { get; set; }

        public long ID { get; set; }

        /// <summary>
        /// 职位ID
        /// </summary>
        public string PositionNo { get; set; }
    }
}
