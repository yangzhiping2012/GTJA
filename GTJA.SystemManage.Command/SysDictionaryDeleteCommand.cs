using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTJA.Common.Interfaces;
using GTJA.SystemManage.DAL;
using GTJA.SystemManage.Model.Domain;

namespace GTJA.SystemManage.Command
{
    class SysDictionaryDeleteCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            long[] ids = context.ConvertParam<long[]>();

            using (var session = SysDbProvider.GetDbContext())
            {
                foreach (var id in ids)
                {
                    var model = session.Get<SysDictionary>(x => x.ID == id);

                    if (session.Get<SysDictionary>(x => x.ParentCode == model.Code) == null)
                    {
                        session.Delete(model);
                    }

                }

                session.SaveChanges();
            }
            return true;
        }
    }
}
