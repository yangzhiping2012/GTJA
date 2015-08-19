using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using GTJA.Common.Core.Encrypt;
using GTJA.Common.Core.Serialize;
using GTJA.SystemManage.AppModel.Common;
using GTJA.SystemManage.DAL;
using GTJA.SystemManage.Model;
using GTJA.SystemManage.Model.Domain;

namespace GTJA.SystemManage.BLL
{
    public class DictionaryBLL
    {
        public static List<SysDictionary> GetDictionarysByParentCode(string parentCode)
        {
            if (string.IsNullOrEmpty(parentCode))
                return null;


            using (var da = SysDbProvider.GetDbContext())
            {
               return  da.Find<SysDictionary>(x => x.ParentCode == parentCode);
            }
        } 
    }
}
