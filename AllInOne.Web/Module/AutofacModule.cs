using AllInOne.Data;
using AllInOne.Data.Infrastructure;
using AllInOne.Services.Provider;
using AllInOne.Services.Provider.Interface;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AllInOne.Web.Module
{
    public class DataModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<User>().As<IUser>().InstancePerRequest();
            builder.RegisterType<BaseUnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            //builder.RegisterType<MedusaDbContext>().As<MedusaDbContext>().InstancePerRequest();
            builder.RegisterType<BaseContextFactory>().As<IBaseContextFactory>().InstancePerRequest();
            builder.Register(c => c.Resolve<IBaseContextFactory>().GetInstance())
                   .As<BaseContext>().InstancePerRequest();
            builder.RegisterAssemblyTypes(Assembly.Load("AllInOne.Data"))
                      .Where(t => t.Name.EndsWith("Repository"))
                      .AsImplementedInterfaces()
                      .InstancePerLifetimeScope();
        }
    }
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("AllInOne.Services"))
                      .Where(t => t.Name.EndsWith("Service"))
                      .AsImplementedInterfaces()
                      .InstancePerLifetimeScope();
        }
    }
    public class WebModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            // Register Common MVC Types
            builder.RegisterModule<AutofacWebTypesModule>();
            // Register MVC Controllers
            builder.RegisterControllers(assembly);
        }
    }
}