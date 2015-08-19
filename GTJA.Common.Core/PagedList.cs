using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTJA.Common.Core
{
    public class PagedList<T> 
    {
        public List<T> Items { get; set; } 

        public PagedList()
        {

        }
        public PagedList(List<T> items, int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            TotalItemCount = items.Count;
            CurrentPageIndex = pageIndex;
            Items = items;
        }

        public PagedList(List<T> items, int pageIndex, int pageSize, int totalItemCount)
        {
            Items = items;
            TotalItemCount = totalItemCount;
            CurrentPageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int ExtraCount { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }
        public int TotalPageCount
        {
            get
            {
                return (int)Math.Ceiling(TotalItemCount / (double)PageSize);
            }
        }

     

    }
}
