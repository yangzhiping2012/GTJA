using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GTJA.Common.Data
{
    public static class DbSessionExtention
    {

        public static List<T> Search<T,S>(this IQueryable<T> query, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex, out int totalCount) 
        {
            totalCount = query.Count();

            var list = query.OrderByDescending(orderBy)
               .Skip((pageIndex - 1) * pageSize)
               .Take(pageSize)
               .ToList();

            return list;
        }
       
    }
}
