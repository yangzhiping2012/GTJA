using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.SystemManage.Model.Domain
{
    public  class SysAction
    {
        public  long ID { get; set; }
        public  string Title { get; set; }
        public  string IconCls { get; set; }
        public  string Click { get; set; }
        public  string ModuleID { get; set; }
        public  string MapRouts { get; set; }
    }
}
