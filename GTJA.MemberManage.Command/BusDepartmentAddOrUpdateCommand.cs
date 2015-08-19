using GTJA.Common.Interfaces;
using GTJA.MemberManage.DAL;
using GTJA.MemberManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.Command
{
    public class BusDepartmentAddOrUpdateCommand : IWebCommand<MemberCommandContext>
    {

        public object Execute(MemberCommandContext context)
        {
            //请求数据
            var request = context.ConvertForm<Department>();
            using (var session = MemberDbProvider.GetDbContext())
            {
                if (!string.IsNullOrEmpty(request.ID))
                {
                    var old = session.Get<Department>(x => x.ID == request.ID);
                     if (old != null)
                     {
                         old.ParentID = request.ParentID;
                         old.Name = request.Name;
                         old.No = request.No;
                         old.Remark = request.Remark;
                         old.State = request.State;
                         session.Update(old);
                     }
                }
                else
                {
                    request.ID = Guid.NewGuid().ToString();
                    session.Insert(request);
                }
                session.SaveChanges();
            }
            return true;
        }
    }
}
