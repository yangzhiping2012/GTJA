using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.AppModel.Response
{
    public class ArticleCategoryModel : TreeGridModel<ArticleCategoryModel>
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string No { get; set; }
        public int State { get; set; }
        public string ParentID { get; set; }
        public int OrderIndex { get; set; }
    }
}
