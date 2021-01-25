using Quiplogs.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;

namespace Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenance
{
    public interface IListPlannedMaintenanceUseCase : IRequestHandler<ListPlannedMaintenanceRequest, ListPlannedMaintenanceResponse>
    {
    }
}
