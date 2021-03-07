using Autofac;
using Quiplogs.Core.Helpers;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.Core.UseCases.Generic;
using Quiplogs.Core.UseCases.User;
using System.Reflection;
using Quiplogs.Core.UseCases.Location;

namespace Quiplogs.Core
{
    public class CoreModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("UseCase")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GetUseCase<,>)).As(typeof(IGetUseCase<,>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(PutUseCase<,>)).As(typeof(IPutUseCase<,>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(PagedListUseCase<,>)).As(typeof(IPagedListUseCase<,>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(ITechnicianListUseCase<,>)).As(typeof(IListUseCase<,>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(RemoveUseCase<,>)).As(typeof(IRemoveUseCase<,>)).InstancePerLifetimeScope();
            
            builder.RegisterType<PutLocationUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<TechnicianListUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<Caching>().As<ICaching>().InstancePerLifetimeScope();
        }
    }
}
