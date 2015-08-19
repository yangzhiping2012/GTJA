using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.Model
{
    /// <summary>
    /// 文章收藏,点赞
    /// </summary>
    public class ArticleFavorite
    {

        /// <summary>
        /// 文章ID
        /// </summary>
        public long ArticleID { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        public string MemberID { get; set; }

        public int ID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 2：点赞 1:收藏
        /// </summary>
        /// <remarks></remarks>
        public int Type { get; set; }
    }
}
