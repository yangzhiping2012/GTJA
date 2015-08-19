using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.SystemManage.Model
{
    public class SysLog 
    {
        public long ID { get; set; }
        /// <summary>
        /// 日志分类：系统运行日志，用户操作日志
        /// </summary>
        public int LogType { get; set; }

        /// <summary>
        /// 事件类型
        /// </summary>
        public int EventType { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// 操作用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public Nullable<DateTime> CreateTime { get; set; }

        /// <summary>
        /// 详细描述
        /// </summary>
        public string Description { get; set; }

    }
}
