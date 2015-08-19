using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GTJA.Common.Data
{
    public class DbContextBase : DbContext, IDataRepository
    {
        #region 构造函数

        public DbContextBase(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
        #endregion

        #region IDataRepository

        public IQueryable<T> All<T>() where T : class
        {
            return this.Set<T>().AsNoTracking();
        }

        public void Update<T>(T entity) where T : class
        {
            var entry = this.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.Set<T>().Attach(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void Insert<T>(T entity) where T : class
        {
            this.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            var entry = this.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.Set<T>().Attach(entity);
            }
            entry.State = EntityState.Deleted;
            this.Set<T>().Remove(entity);
        }

        public T Get<T>(Expression<Func<T, bool>> conditions) where T : class
        {
            return All<T>().FirstOrDefault(conditions);
        }

        public List<T> Find<T>(Expression<Func<T, bool>> conditions = null) where T : class
        {
            if (conditions != null)
            {
                return All<T>().Where(conditions).ToList();
            }
            else
            {
                return All<T>().ToList();
            }

        }

        public List<T> Find<T, S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex, out int totalCount) where T : class
        {
            var queryList = conditions == null ?
                All<T>() :
                All<T>().Where(conditions);

            totalCount = queryList.Count();

            return queryList.OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<T> SqlQuery<T>(string sql) 
        {
            return this.Database.SqlQuery<T>(sql).ToList();
        }

        public List<T> SqlQuery<T>(string sql, int pageIndex, int pageSize, out int total) 
        {
            var query = this.Database.SqlQuery<T>(sql);
            total = query.Count();

            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public int ExecuteSqlCommand(string sql)
        {
            return this.Database.ExecuteSqlCommand(sql);
        }


        #endregion


        public void Delete<T>(Expression<Func<T, bool>> conditions) where T : class
        {
            var list = Find<T>(conditions);
            foreach (var item in list)
            {
                Delete<T>(item);
            }
          
        }
    }
}
