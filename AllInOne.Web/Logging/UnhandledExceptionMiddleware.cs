using Microsoft.Owin;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AllInOne.Web.Logging
{
    public class UnhandledExceptionMiddleware : OwinMiddleware
    {
        public UnhandledExceptionMiddleware(OwinMiddleware next) : base(next)
        { }

        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception ex)
            {
                // log and redirect to a friendly page
                // Use Utils.FormatExceptionMessageToLog
                ILogger logger = LogManager.GetCurrentClassLogger();
            }
        }
    }
}