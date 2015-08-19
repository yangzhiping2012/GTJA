using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.SystemManage.AppModel.Request
{
    public class SysLogListRequest
    {
        public int rows { get; set; }
        public int page { get; set; }

        public int? EventType { get; set; }
        public int? LogType { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string KeyWords { get; set; }
    }
}
