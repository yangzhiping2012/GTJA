using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.SystemManage.AppModel
{
    public class ModuleModel : TreeGridModel<ModuleModel>
    {
        public long ID { get; set; }
        public string ModuleName { get; set; }
        public string Url { get; set; }
        public string ModuleCode { get; set; }
        public int State { get; set; }
    }
}
