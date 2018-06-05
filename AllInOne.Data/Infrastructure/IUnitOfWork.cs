using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {

        //IUserRepository<Author> AuthorRepository { get; }

        /// <summary>
        /// Asynchronously commits all changes
        /// </summary>
        Task CommitAsync();
        /// <summary>
        /// Synchronously commits all changes
        /// </summary>
        void Commit();
    }
}
