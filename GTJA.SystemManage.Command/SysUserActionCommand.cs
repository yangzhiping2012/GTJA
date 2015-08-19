using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using GTJA.Common.Interfaces;
using GTJA.SystemManage.Model.Domain;

namespace GTJA.SystemManage.Command
{
    public class SysUserActionCommand : IWebCommand<SysCommandContext>
    {
        public object Execute(SysCommandContext context)
        {
            var list = new List<SysAction>();

            var sb = new StringBuilder();

            list.ForEach(x =>
            {
                var builder = new TagBuilder("a");
                builder.MergeAttributes(new Dictionary<string, object>(){
                                                   { "icon", x.IconCls },
                                                   { "title",x.Title },
                                                   { "plain","true"},
                                                   { "class","easyui-linkbutton"},
                                                   { "onclick", x.Click }
                                               });
                builder.SetInnerText(x.Title);

                sb.Append(builder.ToString());
            });

            return sb.ToString();
        }
    }
}
