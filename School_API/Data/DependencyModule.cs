using Autofac;
using AutoMapper;
using School_API.Services;

namespace School_API.Data
{
    public class DependencyModule:Module
    {   
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LectorService>().As<ILectorService>().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>().InstancePerLifetimeScope();
        }
    }
}
