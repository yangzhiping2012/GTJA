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
    class SysDictionaryAddCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            var request = context.ConvertForm<SysDictionary>();
            using (var session = SysDbProvider.GetDbContext())
            {
                if (request.ID>0)
                {
                    var old = session.Get<SysDictionary>(x => x.ID == request.ID);
                    if (old != null)
                    {
                        old.Name = request.Name;
                        //old.Code = request.Code; //编码不能修改
                        old.ParentCode = request.ParentCode;
                        session.Update(old);
                    }

                }
                else
                {
                    //检测code是否存在
                    var exists=session.Get<SysDictionary>(x => x.Code == request.Code);
                    if (exists == null)
                    {
                        session.Insert(request);
                    }
                  

                }

                session.SaveChanges();
            }
            return true;
        }
    }
}
