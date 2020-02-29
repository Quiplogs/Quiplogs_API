using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance
{
    public class RemovePlannedMaintenanceRequest : IRequest<RemovePlannedMaintenanceResponse>
    {
        public string Id { get; }
        public RemovePlannedMaintenanceRequest(string id)
        {
            Id = id;
        }
    }
}
