using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AllInOne.Data.Repository.Interface;
using System.Threading.Tasks;
using System.Data.Entity;
//using Microsoft.EntityFrameworkCore;
using AllInOne.Data.Interface;
using System.Threading;

namespace AllInOne.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> Set;
        protected readonly IUnitOfWorkAsync UnitOfWork;

        public BaseRepository(DbContext context, IUnitOfWorkAsync unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Context = context;
            Set = context.Set<T>();
        }

        public virtual T Find(params object[] keyValues)
        {
            return Set.Find(keyValues);
        }

        public virtual IQueryable<T> SelectQuery(string query, params object[] parameters)
        {
            return Set.SqlQuery(query, parameters).AsQueryable();
        }

        public virtual void Insert(T entity)
        {
            Context.Entry(entity).State = EntityState.Added;
        }

        public void ApplyChanges(T entity)
        {
            Context.Entry(entity).State = EntityState.Added;
        }

        public virtual void InsertRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Insert(entity);
            }
        }

        public virtual void InsertGraphRange(IEnumerable<T> entities) => InsertRange(entities);

        public virtual void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(params object[] keyValues)
        {
            var entity = Set.Find(keyValues);
            Delete(entity);
        }

        public virtual void Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void Delete(object id)
        {
            var entity = Set.Find(id);
            Delete(entity);
        }

        public IQueryable<T> Queryable() => Set;

        public IBaseRepository<T> GetRepository<T>() where T : class => UnitOfWork.RepositoryAsync<T>();

        public virtual async Task<T> FindAsync(params object[] keyValues) => await Set.FindAsync(keyValues);

        public virtual async Task<T> FindAsync(CancellationToken cancellationToken, params object[] keyValues) => await Set.FindAsync(cancellationToken, keyValues);

        public virtual async Task<bool> DeleteAsync(params object[] keyValues)
        {
            if (await DeleteAsync(CancellationToken.None, keyValues)) return true;
            return false;
        }

        public virtual async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            var entity = await FindAsync(cancellationToken, keyValues);

            if (entity == null)
            {
                return false;
            }
            Context.Entry(entity).State = EntityState.Deleted;
            return true;
        }
        public virtual void InsertOrUpdateGraph(T entity)
        {
            ApplyChanges(entity);
        }
    }
}
