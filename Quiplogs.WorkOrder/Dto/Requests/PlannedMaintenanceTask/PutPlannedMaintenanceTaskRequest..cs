using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask
{
    public class PutPlannedMaintenanceTaskRequest : IRequest<PutPlannedMaintenanceTaskResponse>
    {
        public string CompanyId { get; set; }
        public string PlannedMaintenanceId { get; set; }
        public string TaskId { get; set; }
        public decimal Quantity { get; set; }

        public PutPlannedMaintenanceTaskRequest(string companyId, string plannedMaintenanceId, string taskId, decimal quantity)
        {
            CompanyId = companyId;
            PlannedMaintenanceId = plannedMaintenanceId;
            TaskId = taskId;
            Quantity = quantity;
        }
    }
}
