using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using ToDo.Core.Data;

namespace ToDo.App
{
    public static class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            RegisterContext(builder);
            RegisterRepositories(builder);
            RegisterServices(builder);
            RegisterControllers(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterContext(ContainerBuilder builder)
        {
            builder.RegisterType<ITContext>().As<DbContext>();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("ToDo.Core"))
                .Where(a =>
                    a.Name.EndsWith("repository", StringComparison.InvariantCultureIgnoreCase) &&
                    a.Namespace.EndsWith("repositories.impl", StringComparison.InvariantCultureIgnoreCase)
                )
                .AsImplementedInterfaces();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("ToDo.Core"))
                .Where(a =>
                    a.Name.EndsWith("service", StringComparison.InvariantCultureIgnoreCase) &&
                    a.Namespace.EndsWith("services.impl", StringComparison.InvariantCultureIgnoreCase)
                )
                .AsImplementedInterfaces();
        }

        private static void RegisterControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }
    }
}