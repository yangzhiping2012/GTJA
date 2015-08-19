﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.SystemManage.AppModel.Response
{
    public class DictionaryModel : TreeGridModel<DictionaryModel>
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ParentCode { get; set; }
    }
}
