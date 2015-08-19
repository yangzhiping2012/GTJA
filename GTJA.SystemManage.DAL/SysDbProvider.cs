using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTJA.Common.Data;

namespace GTJA.SystemManage.DAL
{
    public class SysDbProvider 
    {
        public static IDataRepository GetDbContext()
        {
            return new SysDbContext();
        }
    }
}
