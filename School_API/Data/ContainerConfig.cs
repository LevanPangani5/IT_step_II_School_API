using Autofac;
using School_API.Services;

namespace School_API.Data
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ILectorService>().As<LectorService>();
            builder.RegisterType<IApplicationDbContext>().As<ApplicationDbContext>();

            return builder.Build();
        }
    }
}
