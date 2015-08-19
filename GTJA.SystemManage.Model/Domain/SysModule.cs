using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.SystemManage.Model
{
    public class SysModule 
    {
        public SysModule()
        {
            State = 1;
        }

        public long ID { get; set; }

        public string ModuleName { get; set; }
        public string Url { get; set; }
        public string ParentCode { get; set; }
        public string Remark { get; set; }
        public int State { get; set; }
        public string ModuleCode { get; set; }
    }
}
