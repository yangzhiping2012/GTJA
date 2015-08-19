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
    class SysSettingSaveCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            var request = context.ConvertParam<List<PropertyGridModel>>();
            using (var session = SysDbProvider.GetDbContext())
            {
                foreach (var propertyGridModel in request)
                {
                    var model = session.Get<SysSetting>(x => x.Code == propertyGridModel.code);
                    if (model != null)
                    {
                        model.Value = propertyGridModel.value;
                        session.Update(model);
                    }


                }

                session.SaveChanges();
            }

            return  true;
        }
    }
}
