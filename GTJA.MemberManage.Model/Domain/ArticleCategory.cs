using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.Model
{
    /// <summary>
    /// 文章分类表
    /// </summary>
    public class ArticleCategory
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 分类编号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderIndex { get; set; }

        /// <summary>
        /// 装态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public string ParentID { get; set; }
    }
}
