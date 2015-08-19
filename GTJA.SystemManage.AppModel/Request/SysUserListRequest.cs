using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.SystemManage.AppModel.Request
{
    public class SysUserListRequest
    {
        public int rows { get; set; }
        public int page { get; set; }
        public string KeyWords{ get; set; }
    }
}
