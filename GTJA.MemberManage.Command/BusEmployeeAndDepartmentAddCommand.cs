using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTJA.Common.Interfaces;
using GTJA.MemberManage.AppModel.Request;
using GTJA.MemberManage.DAL;
using GTJA.MemberManage.Model;

namespace GTJA.MemberManage.Command
{
    public class BusEmployeeAndDepartmentAddCommand : IWebCommand<MemberCommandContext>
    {
        public object Execute(MemberCommandContext context)
        {
            var request = context.ConvertParam<BusEmployeeAndDepartmentAddRequest>();
            using (var session = MemberDbProvider.GetDbContext())
            {

                //删除老的
                session.Delete<DepartmentAndMember>(x => x.MemberID == request.ID);

                foreach (var s in request.Ids)
                {
                    var arr2 = s.Split('#');
                    var m = new DepartmentAndMember()
                    {
                        MemberID = request.ID,
                        DepartmentID = arr2[0],
                        PositionNo = arr2[1]
                    };
                    session.Insert(m);
                }

                session.SaveChanges();
            }

            return true;
        }
    }
}
