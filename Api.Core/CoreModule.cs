using Api.Core.Helpers;
using Autofac;
using System.Reflection;

namespace Api.Core
{
    public class CoreModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("UseCase")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<Caching>().As<ICaching>().InstancePerLifetimeScope();
        }
    }
}
