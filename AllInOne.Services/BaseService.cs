using AllInOne.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Services
{
    public class BaseService : IBaseService
    {
        public BaseService(IUnitOfWork unitOfWork)
        {
        }

    }
}
