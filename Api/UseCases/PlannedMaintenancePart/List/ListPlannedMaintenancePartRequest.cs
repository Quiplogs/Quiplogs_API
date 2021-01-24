using System;

namespace Api.UseCases.PlannedMaintenancePart.List
{
    public class ListPlannedMaintenancePartRequest
    {
        public Guid PlannedMaintenanceId { get; set; }
        public int PageNumber { get; set; }

        public Guid CompanyId { get; set; }
    }
}
