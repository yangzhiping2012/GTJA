using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.Model
{
    /// <summary>
    /// 会员表
    /// </summary>
    public class Member
    {
        public Member()
        {
            AddTime = DateTime.Now;
        }
        /// <summary>
        /// 编号
        /// </summary>
        [MaxLength(50)]
        public string ID { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 会员类别：外键关联MemberType
        /// </summary>
        public string MemberType { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// 住址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 资产量：需要加密
        /// </summary>
        public decimal Asset { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 身份证号：需要加密
        /// </summary>
        public string IDCard { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 营业部ID：用于投顾关联到营业点，外键关联Station表
        /// </summary>
        public string StationID { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Profile { get; set; }

         /// <summary>
        /// 资金账号 需要加密
        /// </summary>
        public string FundAccount { get; set; }
         /// <summary>
        /// 开户日期
        /// </summary>
        public Nullable<DateTime> OpeningDate { get; set; }

        /// <summary>
        /// 营销人员
        /// </summary>
        public string MarketingPerson { get; set; }

        /// <summary>
        /// 当月总资产，需要加密
        /// </summary>
        public decimal AssetOfMonth { get; set; }

         /// <summary>
        /// 净佣金，需要加密
        /// </summary>
        public decimal NetCommission { get; set; }
        
    }
}
