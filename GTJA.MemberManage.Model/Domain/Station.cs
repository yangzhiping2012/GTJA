using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.Model
{
    /// <summary>
    /// 营业点：例如顺城营业点
    /// </summary>
    public class Station
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [MaxLength(50)]
        public string ID { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }


        public string ParentID { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel { get; set; }
    }
}
