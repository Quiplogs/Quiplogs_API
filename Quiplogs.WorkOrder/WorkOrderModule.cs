using Autofac;
using Microsoft.Extensions.Configuration;
using Quiplogs.WorkOrder.Interfaces.Services;
using Quiplogs.WorkOrder.Services;
using Quiplogs.WorkOrder.UseCases.WorkOrder;
using Quiplogs.WorkOrder.UseCases.WorkOrderPart;
using Quiplogs.WorkOrder.UseCases.WorkOrderTask;

namespace Quiplogs.WorkOrder
{
    public class WorkOrderModule : Module
    {
        private readonly IConfiguration _configuration;

        public WorkOrderModule(IConfiguration configuration) => this._configuration = configuration;

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NotificationService>()
                .As<INotificationService>()
                .WithParameter(new TypedParameter(typeof(IConfiguration), (object)this._configuration))
                .InstancePerLifetimeScope();

            builder.RegisterType<WorkOrderPagedListUseCase>().InstancePerDependency();
            builder.RegisterType<ListWorkOrderPartUseCase>().InstancePerDependency();
            builder.RegisterType<ListWorkOrderTaskUseCase>().InstancePerDependency();
            builder.RegisterType<GetWorkOrderUseCase>().InstancePerDependency();
            builder.RegisterType<PutWorkOrderUseCase>().InstancePerDependency();

            builder.RegisterType<PutWorkOrderPartUseCase>().InstancePerLifetimeScope();
        }
    }
}
