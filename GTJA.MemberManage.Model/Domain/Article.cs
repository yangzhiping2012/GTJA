using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.Model
{
    /// <summary>
    /// 文章表
    /// </summary>
    public class Article
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 发表人：外键关联会员ID
        /// </summary>
        public string MemberID { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 推荐
        /// </summary>
        public int Recommend { get; set; }

        /// <summary>
        /// 置顶
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// 阅读次数
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        /// 关注数
        /// </summary>
        public int FollowCount { get; set; }

        /// <summary>
        /// 评论条数
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        /// 收藏数
        /// </summary>
        public int FavoriteCount { get; set; }

        /// <summary>
        /// 点赞次数
        /// </summary>
        public int SupportCount { get; set; }

        /// <summary>
        /// 发布范围：发送给付费会员、全站公开
        /// </summary>
        public int PublishLevel { get; set; }

        /// <summary>
        /// 分类ID：外键关联ArticleCategory
        /// </summary>
        public string CategoryID { get; set; }

        /// <summary>
        /// 文章积分：针对精囊妙计需要积分才能查看
        /// </summary>
        public int Score { get; set; }
    }
}
