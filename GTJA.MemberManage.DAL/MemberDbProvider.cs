using GTJA.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.DAL
{
    public class MemberDbProvider
    {
        public static IDataRepository GetDbContext()
        {
            return new MemberDbContext();
        }
    }
}
