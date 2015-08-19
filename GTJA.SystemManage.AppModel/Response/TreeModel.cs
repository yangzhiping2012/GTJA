using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.SystemManage.AppModel
{
    public class TreeModel
    {
        public TreeModel()
        {
            children = new List<TreeModel>();
        }
        public string id { get; set; }
        public string text { get; set; }
        public string state { get; set; }
        public List<TreeModel> children { get; set; }
        public bool @checked { get; set; }



        public string code { get; set; }
    }
}
