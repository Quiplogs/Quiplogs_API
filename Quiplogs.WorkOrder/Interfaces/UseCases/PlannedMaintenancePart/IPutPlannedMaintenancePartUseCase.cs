using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;

namespace Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenancePart
{
    public interface IPutPlannedMaintenancePartUseCase : IRequestHandler<PutPlannedMaintenancePartRequest, PutPlannedMaintenancePartResponse>
    {
    }
}
