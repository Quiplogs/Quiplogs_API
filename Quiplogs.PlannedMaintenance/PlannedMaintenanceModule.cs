using Autofac;
using Quiplogs.PlannedMaintenance.UseCases.PlannedMaintenance;
using Quiplogs.PlannedMaintenance.UseCases.PlannedMaintenancePart;
using Quiplogs.PlannedMaintenance.UseCases.PlannedMaintenanceTask;

namespace Quiplogs.PlannedMaintenance
{
    public class PlannedMaintenanceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PlannedMaintenancePagedListUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<ListPlannedMaintenancePartUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<ListPlannedMaintenanceTaskUseCase>().InstancePerLifetimeScope();

            builder.RegisterType<PutPlannedMaintenancePartUseCase>().InstancePerLifetimeScope();
        }
    }
}
