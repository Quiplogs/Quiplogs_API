using Autofac;
using Quiplogs.WorkOrder.UseCases.WorkOrder;
using Quiplogs.WorkOrder.UseCases.WorkOrderPart;
using Quiplogs.WorkOrder.UseCases.WorkOrderTask;

namespace Quiplogs.WorkOrder
{
    public class WorkOrderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WorkOrderPagedListUseCase>().InstancePerDependency();
            builder.RegisterType<ListWorkOrderPartUseCase>().InstancePerDependency();
            builder.RegisterType<ListWorkOrderTaskUseCase>().InstancePerDependency();
            builder.RegisterType<GetWorkOrderUseCase>().InstancePerDependency();
        }
    }
}
