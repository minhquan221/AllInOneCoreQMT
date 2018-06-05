using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Services;

namespace AllInOne.Web.ServiceProvider
{
    public static class ContainerConfig<T> where T: class
    {
        public static Autofac.IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BaseService<T>>().As<IBaseService<T>>();
            // add other registrations here...

            return builder.Build();
        }
    }
}
