using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.MemberManage.Model.Domain
{
    /// <summary>
    /// 投资组合详细
    /// </summary>
    public class PortfolioDetail
    {
        public long ID { get; set; }


        public long PortfolioID { get; set; }

        /// <summary>
        /// 股票代码
        /// </summary>
        public string StockCode { get; set; }

        /// <summary>
        /// 比例
        /// </summary>
        public int Ratio { get; set; }
    }

}
