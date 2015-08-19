using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTJA.Common.Data;
using GTJA.MemberManage.DAL;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace GTJA.MemberManage.DataImport
{
    public abstract class ExcelImportBase : IExcelImport
    {
        #region 变量
        private readonly string _filePath;
        private string _error;
        private List<List<string>> dataRow;
        protected readonly IDataRepository repository;
        #endregion

        #region 构造函数

        protected ExcelImportBase(string filepath)
        {
            _filePath = filepath;
            dataRow = new List<List<string>>();
            repository = MemberDbProvider.GetDbContext();
        }
        #endregion

        #region IExcelImport

        public bool Save()
        {
            try
            {
                GetDataRow();
                ValidDataRow();
                SaveDataRow();
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return false;
            }


            return true;
        }
        public string Error
        {
            get { return _error; }
        }

        public void Dispose()
        {

        }
        #endregion

        #region abstract method

        protected abstract void ValidDataRow(List<string> list);
        protected abstract void SaveRow(List<string> values);
        #endregion
       

        #region 辅助方法

        private void SaveDataRow()
        {
           
            foreach (List<string> list in dataRow)
            {
                SaveRow(list);
            }

            repository.SaveChanges();

            repository.Dispose();
        }

        private void ValidDataRow()
        {
            foreach (List<string> list in dataRow)
            {
                ValidDataRow(list);
            }
        }


        /// <summary>
        /// 读取行
        /// </summary>
        private void GetDataRow()
        {

            using (FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
            {
                HSSFWorkbook xworkbook = new HSSFWorkbook(fs);
                HSSFSheet xsheet = (HSSFSheet)xworkbook.GetSheetAt(0); //工作薄
                int rowsCount = xsheet.PhysicalNumberOfRows; //行数
                int colsCount = xsheet.GetRow(0).PhysicalNumberOfCells; //列数

                for (var i = 1; i < rowsCount; i++)
                {
                    var row = xsheet.GetRow(i);
                    var colsValue = new List<string>();

                    for (var j = 0; j < colsCount; j++)
                    {
                        var cell = row.GetCell(j);
                        if (cell != null)
                        {
                            if (cell.CellType == CellType.Numeric)
                            {
                                var value = cell.NumericCellValue;
                                colsValue.Add(value.ToString());
                            }
                            else if (cell.CellType == CellType.String)
                            {
                                var value = cell.StringCellValue;
                                colsValue.Add(value);
                            }
                            else
                            {
                                colsValue.Add("");
                            }
                        }
                        else
                        {
                            colsValue.Add("");
                        }

                    }

                    dataRow.Add(colsValue);
                }
                xsheet = null;
                xworkbook = null;
            }

        }

        #endregion

    }
}
