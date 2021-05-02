using Autofac;
using System.Reflection;
using Quiplogs.Inventory.UseCases.Part;

namespace Quiplogs.Inventory
{
    public class InventoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("UseCase")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<PutPartUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<RemovePartUseCase>().InstancePerLifetimeScope();
        }
    }
}
