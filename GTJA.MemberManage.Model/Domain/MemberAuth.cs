using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.Model
{
    /// <summary>
    /// 会员短信验证码
    /// </summary>
    public class MemberAuth
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 验证类别：手机号、邮箱、微信..
        /// </summary>
        public int AuthType { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string ValidCode { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpiredTime { get; set; }

        /// <summary>
        /// 验证账号信息-手机号、邮箱
        /// </summary>
        public string AuthIdentity { get; set; }
    }
}
