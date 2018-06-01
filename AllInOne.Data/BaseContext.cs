using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AllInOne.Data
{
    public class BaseContext: DbContext
    {
        private DbContext _dbContext;
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
            
        }
    }
}
