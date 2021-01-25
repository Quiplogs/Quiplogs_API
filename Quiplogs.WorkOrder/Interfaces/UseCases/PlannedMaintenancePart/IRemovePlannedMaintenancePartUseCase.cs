using Quiplogs.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;

namespace Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenancePart
{
    public interface IRemovePlannedMaintenancePartUseCase : IRequestHandler<RemovePlannedMaintenancePartRequest, RemovePlannedMaintenancePartResponse>
    {
    }
}
