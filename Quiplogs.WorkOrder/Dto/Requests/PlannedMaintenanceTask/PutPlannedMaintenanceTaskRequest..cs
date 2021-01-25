using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask
{
    public class PutPlannedMaintenanceTaskRequest : IRequest<PutPlannedMaintenanceTaskResponse>
    {
        public Guid CompanyId { get; set; }
        public Guid PlannedMaintenanceId { get; set; }
        public Guid TaskId { get; set; }
        public decimal Quantity { get; set; }

        public PutPlannedMaintenanceTaskRequest(Guid companyId, Guid plannedMaintenanceId, Guid taskId, decimal quantity)
        {
            CompanyId = companyId;
            PlannedMaintenanceId = plannedMaintenanceId;
            TaskId = taskId;
            Quantity = quantity;
        }
    }
}
