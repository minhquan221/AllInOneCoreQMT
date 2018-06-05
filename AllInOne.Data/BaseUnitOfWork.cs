using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Data.Infrastructure;

namespace AllInOne.Data
{
    public class BaseUnitOfWork : IUnitOfWork
    {
        private readonly BaseContext _dbContext;
        #region Repositories
        //public IRepository<User> UserRepository = new GenericRepository<User>(_dbContext);
        #endregion
        public BaseUnitOfWork(BaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
