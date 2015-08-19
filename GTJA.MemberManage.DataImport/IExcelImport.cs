using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTJA.MemberManage.DataImport
{
    public interface IExcelImport : IDisposable
    {
        string Error { get;  }
        bool Save();
    }
}
