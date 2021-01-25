using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask
{
    public class RemovePlannedMaintenanceTaskRequest : IRequest<RemovePlannedMaintenanceTaskResponse>
    {
        public Guid Id { get; }
        public RemovePlannedMaintenanceTaskRequest(Guid id)
        {
            Id = id;
        }
    }
}
