using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Data.Repository.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        T Find(params object[] keyValues);
        IQueryable<T> SelectQuery(string query, params object[] parameters);
        void Insert(T entity);
        void ApplyChanges(T entity);
        void InsertRange(IEnumerable<T> entities);
        void InsertOrUpdateGraph(T entity);
        void InsertGraphRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(params object[] keyValues);
        void Delete(T entity);
        IQueryable<T> Queryable();
        IBaseRepository<T> GetRepository<T>() where T : class;

    }
}
