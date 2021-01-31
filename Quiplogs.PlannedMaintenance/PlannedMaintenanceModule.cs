using Autofac;
using Quiplogs.PlannedMaintenance.UseCases.PlannedMaintenance;
using Quiplogs.PlannedMaintenance.UseCases.PlannedMaintenancePart;
using Quiplogs.PlannedMaintenance.UseCases.PlannedMaintenanceTask;

namespace Quiplogs.PlannedMaintenance
{
    public class PlannedMaintenanceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PlannedMaintenancePagedListUseCase>().InstancePerDependency();
            builder.RegisterType<ListPlannedMaintenancePartUseCase>().InstancePerDependency();
            builder.RegisterType<ListPlannedMaintenanceTaskUseCase>().InstancePerDependency();
        }
    }
}
