using Autofac;
using System.Reflection;

namespace Quiplogs.WorkOrder
{
    public class WorkOrderModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("UseCase")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
