using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.AppModel.Response
{
    public class StationModel : TreeGridModel<StationModel>
    {
        public string ID { get; set; }

        public string Name { get; set; }
        public string ParentID { get; set; }
        public string Tel { get; set; }

        public string Remark { get; set; }

        public string Address { get; set; }

    }
}
