using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.DataImport
{
    public class MemberImport : ExcelImportBase, IExcelImport
    {
        public MemberImport(string filePath)
            : base(filePath)
        {

        }


        #region ExcelImportBase

        protected override void ValidDataRow(List<string> list)
        {
            
        }

        protected override void SaveRow(List<string> values)
        {
           
        } 
        #endregion
    }
}
