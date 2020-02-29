using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask
{
    public class RemovePlannedMaintenanceTaskRequest : IRequest<RemovePlannedMaintenanceTaskResponse>
    {
        public string Id { get; }
        public RemovePlannedMaintenanceTaskRequest(string id)
        {
            Id = id;
        }
    }
}
