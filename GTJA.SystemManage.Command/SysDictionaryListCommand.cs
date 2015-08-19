using GTJA.Common.Data;
using GTJA.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using GTJA.SystemManage.AppModel;
using GTJA.SystemManage.AppModel.Response;
using GTJA.SystemManage.DAL;
using GTJA.SystemManage.Model;
using GTJA.SystemManage.Model.Domain;

namespace GTJA.SystemManage.Command
{
    public class SysDictionaryListCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            
            var list = new List<DictionaryModel>();
            using (var session = SysDbProvider.GetDbContext())
            {
                
                var roots = session.All<SysDictionary>()
                    .Where(x => string.IsNullOrEmpty(x.ParentCode) )
                    .ToList();

                roots.ForEach(x =>
                {
                    var model = new DictionaryModel();
                    model.Code = x.Code;
                    model.Name = x.Name;
                    model.ParentCode = x.ParentCode;
                    model.ID = x.ID;
                    GetChilds(session, model);
                    list.Add(model);
                });

            }


            return list;
        }

        private void GetChilds(IDataRepository session, DictionaryModel parent)
        {
            var childs = session.All<SysDictionary>()
                .Where(x => x.ParentCode == parent.Code )
                .ToList();
            if (childs.Count > 0)
            {
                childs.ForEach(x =>
                {
                    var model = new DictionaryModel();
                    model.Code = x.Code;
                    model.Name = x.Name;
                    model.ParentCode = x.ParentCode;
                    model.ID = x.ID;
                    GetChilds(session, model);
                    parent.children.Add(model);
                });
            }
            else
            {
                parent.state = "open";
            }
        }
    }
}
