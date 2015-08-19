using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.SystemManage.Model
{
    public class SysUser 
    {
        public SysUser()
        {
            State = 1;
        }
        public long ID { get; set; }
        public string LoginName { get; set; }
        public string TrueName { get; set; }
        public string LoginPass { get; set; }
        public string PoneNumber { get; set; }
        public string WorkNumber { get; set; }
        public int State { get; set; }
    }
}
