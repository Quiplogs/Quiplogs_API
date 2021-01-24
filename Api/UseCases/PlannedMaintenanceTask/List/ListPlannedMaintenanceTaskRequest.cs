using System;

namespace Api.UseCases.PlannedMaintenanceTask.List
{
    public class ListPlannedMaintenanceTaskRequest
    {
        public Guid PlannedMaintenanceId { get; set; }
        public int PageNumber { get; set; }
        public Guid CompanyId { get; set; }
    }
}
