using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Data.Interface;
using AllInOne.Data.Infrastructure;
using AllInOne.Models;

namespace AllInOne.Data.Repository
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        private BaseContext _dbContext;
        public UserRepository(BaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        #region Override GenericRepository



        #endregion

        #region Overload GenericRepository

        public bool Update(User t)
        {
            if (t == null)
                return false;
            User result = Update(t, t.Id);
            if (result == null)
                return false;
            return true;
        }

        #endregion

    }
}
