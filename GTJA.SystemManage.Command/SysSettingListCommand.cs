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
    class SysSettingListCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            var list = new List<PropertyGridModel>();
            var total = 0;
            using (var session = SysDbProvider.GetDbContext())
            {
                var all = session.Find<SysSetting>();
                total = all.Count;
                all.ForEach(x =>
                {
                    var model = new PropertyGridModel();
                    model.name = x.Name;
                    model.value = x.Value;
                    model.group = "";
                    model.editor = "text";
                    model.code = x.Code;

                    list.Add(model);
                });
            }
            return new { total = total, rows = list };
        }
    }
}
