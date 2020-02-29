using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;

namespace Quiplogs.PlannedMaintenance.Interfaces.UseCases.PlannedMaintenance
{
    public interface IRemovePlannedMaintenanceUseCase : IRequestHandler<RemovePlannedMaintenanceRequest, RemovePlannedMaintenanceResponse>
    {
    }
}
