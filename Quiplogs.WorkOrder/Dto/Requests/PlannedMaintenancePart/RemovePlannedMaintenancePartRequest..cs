using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart
{
    public class RemovePlannedMaintenancePartRequest : IRequest<RemovePlannedMaintenancePartResponse>
    {
        public string Id { get; }
        public RemovePlannedMaintenancePartRequest(string id)
        {
            Id = id;
        }
    }
}
