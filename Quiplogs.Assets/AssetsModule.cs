using Autofac;
using Quiplogs.Assets.UseCases.Asset;
using Quiplogs.Assets.UseCases.AssetUsage;
using System.Reflection;

namespace Quiplogs.Assets
{
    public class AssetsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("UseCase")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<AssetPagedListUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<AssetUsagePagedListUseCase>().InstancePerLifetimeScope();
        }
    }
}
