using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Services
{
    public class BaseService<T>: IBaseService where T: class
    {
        public BaseService(T t)
        {

        }
    }
}
