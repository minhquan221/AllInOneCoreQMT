using AllInOne.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AllInOne.Web.ServiceProvider
{
    public class BaseContextFactory: BaseContext
    {
        private readonly BaseContext _dbContext;
        public BaseContextFactory(string ConnectionString) : base(ConnectionString)
        {
            ConnectionString = GetConnectionString();
            _dbContext = new BaseContext(ConnectionString);
        }

        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[Constant.connectionDefault].ConnectionString;
        }
    }
}
