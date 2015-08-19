using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GTJA.Common.Data
{
    public interface IDataRepository : IDisposable
    {
        int SaveChanges();
        IQueryable<T> All<T>() where T : class;
        void Update<T>(T entity) where T : class;
        void Insert<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Delete<T>(Expression<Func<T, bool>> conditions) where T : class;
        T Get<T>(Expression<Func<T, bool>> conditions) where T : class;
        List<T> Find<T>(Expression<Func<T, bool>> conditions = null) where T : class;
        List<T> Find<T, S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex, out int totalCount) where T : class;
        List<T> SqlQuery<T>(string sql);
        List<T> SqlQuery<T>(string sql, int pageIndex, int pageSize, out int total) ;
        int ExecuteSqlCommand(string sql);
    }
}
