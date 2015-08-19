using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.SystemManage.Model
{
    public class SysRole
    {
        public SysRole()
        {
            State = 1;
        }

        public long ID { get; set; }
        public string RoleName { get; set; }
        public string Remark { get; set; }
        public int State { get; set; }
    }
}
