using System;

namespace Api.UseCases.PlannedMaintenancePart.Put
{
    public class PutPlannedMaintenancePartRequest
    {
        public Guid CompanyId { get; set; }
        public Guid PlannedMaintenanceId { get; set; }
        public Guid PartId { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
    }
}
