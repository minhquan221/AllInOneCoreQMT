using AllInOne.Models;
using AllInOne.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
    }
}
