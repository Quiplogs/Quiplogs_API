using System;

namespace Api.UseCases.PlannedMaintenance.List
{
    public class ListPlannedMaintenanceRequest
    {
        public Guid CompanyId { get; set; }
        public Guid LocationId { get; set; }
        public Guid AssetId { get; set; }
        public bool ShouldPage { get; set; }
        public int PageNumber { get; set; }
    }
}
