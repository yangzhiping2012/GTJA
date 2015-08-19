using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.SystemManage.AppModel
{
   public  class SysMenuModel
    {
        public SysMenuModel()
        {
            menus = new List<SysMenuModel>();
        }

        public string id { get; set; }
        public string text { get; set; }
        public string iconCls { get; set; }
        public string url { get; set; }
        public List<SysMenuModel> menus { get; set; }
    }
}
