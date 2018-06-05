using AllInOne.Data.Repository.Interface;
using AllInOne.Data.Repository;
using CommonServiceLocator;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using AllInOne.Data.Interface;
using System.Data.Entity.Infrastructure;

namespace AllInOne.Data.Infracture
{
  public class UnitOfWork : IUnitOfWorkAsync
    {
        private readonly DbContext _context;
        protected DbTransaction Transaction;
        protected Dictionary<string, dynamic> Repositories;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            Repositories = new Dictionary<string, dynamic>();
        }

        public virtual IBaseRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (ServiceLocator.IsLocationProviderSet)
            {
                return ServiceLocator.Current.GetInstance<IBaseRepository<TEntity>>();
            }

            return Repository<TEntity>();
        }

        public virtual int SaveChanges() => _context.SaveChanges();

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public virtual IBaseRepository<TEntity> RepositoryAsync<TEntity>() where TEntity : class
        {
            if (ServiceLocator.IsLocationProviderSet)
            {
                return ServiceLocator.Current.GetInstance<IBaseRepository<TEntity>>();
            }

            if (Repositories == null)
            {
                Repositories = new Dictionary<string, dynamic>();
            }

            var type = typeof(TEntity).Name;

            if (Repositories.ContainsKey(type))
            {
                return (IBaseRepository<TEntity>)Repositories[type];
            }

            var repositoryType = typeof(BaseRepository<>);

            Repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context, this));

            return Repositories[type];
        }

        public virtual int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _context.Database.ExecuteSqlCommand(sql, parameters);
        }

        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await _context.Database.ExecuteSqlCommandAsync(sql, parameters);
        }

        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken, params object[] parameters)
        {
            return await _context.Database.ExecuteSqlCommandAsync(sql, cancellationToken, parameters);
        }

        public virtual void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            var objectContext = ((IObjectContextAdapter) _context).ObjectContext;
            if (objectContext.Connection.State != ConnectionState.Open)
            {
                objectContext.Connection.Open();
            }
            Transaction = objectContext.Connection.BeginTransaction(isolationLevel);
        }

        public int? CommandTimeout
        {
            get => _context.Database.CommandTimeout;
            set => _context.Database.CommandTimeout = value;
        }

        public virtual bool Commit()
        {
            Transaction.Commit();
            return true;
        }

        public virtual void Rollback()
        {
            Transaction.Rollback();
        }
    }
}
