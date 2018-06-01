using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AllInOne.Data.Repository.Interface;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace AllInOne.Data.Repository
{
    public class BaseRepository<T>: IBaseRepository<T> where T: class
    {
        public T Insert(T t)
        {
            return t;
        }

        public T Update(T t)
        {
            return t;
        }

        public bool Delete(T t)
        {
            return true;
        }

        public IEnumerable<T> Get(Expression<Func<T, object>>[] expressions)
        {
            List<T> t = new List<T>();
            return t;
        }

        public IEnumerable<T> GetAll()
        {
            List<T> t = new List<T>();
            return t;
        }
    }
}
