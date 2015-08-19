using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTJA.Common.Interfaces;
using GTJA.SystemManage.AppModel.Response;
using GTJA.SystemManage.DAL;
using GTJA.SystemManage.Model.Domain;

namespace GTJA.SystemManage.Command
{
    public class SysMemberTypeListCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            using (var session = SysDbProvider.GetDbContext())
            {

                return session.All<SysDictionary>()
                    .Where(x => x.ParentCode == "MemberType")
                    .ToList();


            }
        }
    }
}
