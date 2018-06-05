using AllInOne.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Data.Repository;
using System.Linq.Expressions;
using AllInOne.Models;
using AllInOne.Data.Infrastructure;
using AllInOne.Data.Interface;

namespace AllInOne.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userRepository;
        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository) : base(unitOfWork)
        {
            _uow = unitOfWork;
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll().ToList();
        }
    }
}
