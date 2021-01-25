using System.Reflection;
using Autofac;
using Quiplogs.Core.Helpers;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.Core.UseCases.Generic;

namespace Quiplogs.Core
{
    public class CoreModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("UseCase")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GetUseCase<,>)).As(typeof(IGetUseCase<,>)).InstancePerDependency();

            builder.RegisterType<Caching>().As<ICaching>().InstancePerLifetimeScope();
        }
    }
}
