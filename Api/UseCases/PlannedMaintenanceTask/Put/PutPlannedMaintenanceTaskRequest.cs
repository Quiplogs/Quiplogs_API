using System;

namespace Api.UseCases.PlannedMaintenanceTask.Put
{
    public class PutPlannedMaintenanceTaskRequest
    {
        public Guid CompanyId { get; set; }
        public Guid PlannedMaintenanceId { get; set; }
        public Guid TaskId { get; set; }
        public decimal Quantity { get; set; }
    }
}
