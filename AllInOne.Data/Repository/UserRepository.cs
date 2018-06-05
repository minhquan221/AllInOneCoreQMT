using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Data.Interface;
using AllInOne.Data.Repository.Interface;
using AllInOne.Models;
using AllInOne.Models.Interface;

namespace AllInOne.Data.Repository
{
    public class UserRepository: BaseRepository<IUser>, IUserRepository
    {

        public UserRepository(DbContext context, IUnitOfWorkAsync unitOfWork): base(context, unitOfWork)
        {
            
        }
        #region override method BaseRepository
        #endregion

        #region overload method BaseRepository
        #endregion


    }
}
