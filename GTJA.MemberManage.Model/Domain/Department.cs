using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.Model
{
    /// <summary>
    /// 部门
    /// </summary>
    public class Department
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [MaxLength(50)]
        public string ID { get; set; }

        /// <summary>
        /// 部门编码
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父级部门
        /// </summary>
        public string ParentID { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }


        /// <summary>
        /// 分公司
        /// </summary>
        public string StationID { get; set; }
    }
}
