using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Data.Repository.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        T Insert(T t);

        T Update(T t);

        bool Delete(T t);

        IEnumerable<T> Get(Expression<Func<T, object>>[] expressions);

        IEnumerable<T> GetAll();

    }
}
