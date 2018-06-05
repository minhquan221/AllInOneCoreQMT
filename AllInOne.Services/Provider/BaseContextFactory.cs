using AllInOne.Data;
using AllInOne.Services.Provider.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AllInOne.Services.Provider
{
    public class BaseContextFactory: IBaseContextFactory
    {
        public BaseContext GetInstance()
        {
            String connectionString = this.GetConnectionString(HttpContext.Current);
            return new BaseContext(connectionString);
        }

        private String GetConnectionString(HttpContext context)
        {
            // do what you want
            //if (context.Session[Common.Constant.SessionLoginKey] == null)
            //{
            //    return Common.Constant.MasterDataConnection;
            //}
            //return Common.Constant.MasterDataConnection;
            return null;
        }
    }
}
