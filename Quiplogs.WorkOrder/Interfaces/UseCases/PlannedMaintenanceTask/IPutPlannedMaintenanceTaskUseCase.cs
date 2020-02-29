using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask;

namespace Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenanceTask
{
    public interface IPutPlannedMaintenanceTaskUseCase : IRequestHandler<PutPlannedMaintenanceTaskRequest, PutPlannedMaintenanceTaskResponse>
    {
    }
}
