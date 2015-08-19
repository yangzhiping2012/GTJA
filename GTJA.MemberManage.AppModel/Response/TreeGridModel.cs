using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.AppModel
{
    public class TreeGridModel<T> 
    {
        public TreeGridModel()
        {
            children = new List<T>();
        }
        public List<T> children { get; set; }
        public string state { get; set; }
        public string iconCls { get; set; }
    }
}
