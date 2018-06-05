using AllInOne.Data.Infrastructure;
using AllInOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Data.Interface
{
    public interface IUserRepository: IBaseRepository<User>
    {
        bool Update(User t);
    }
}
