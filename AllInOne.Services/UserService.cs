using AllInOne.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Data.Repository;
using System.Linq.Expressions;
using AllInOne.Models;

namespace AllInOne.Services
{
    public class UserService: BaseService<UserRepository>, IUserService
    {
        private UserRepository _userRepository;
        public UserService(UserRepository userRepository): base(userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<IUser> GetListUserByUserNameEmail(string UserName, string Email)
        {
            Expression<Func<IUser, object>>[] expressions = {
                x => x.Username == UserName,
                x =>  x.Email == Email
            };
            return _userRepository.Get(expressions);
        }
    }
}
