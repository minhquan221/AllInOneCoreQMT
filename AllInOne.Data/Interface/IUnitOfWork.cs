using AllInOne.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Data.Interface
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        int ExecuteSqlCommand(string sql, params object[] parameters);
        IBaseRepository<TEntity> Repository<TEntity>() where TEntity : class;
        int? CommandTimeout { get; set; }
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}
