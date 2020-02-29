using Api.Core.Domain.Entities;
using Quiplogs.Inventory.Domain.Entities;

namespace Quiplogs.WorkOrder.Domain.Entities
{
    public class PlannedMaintenancePart : BaseEntity
    {
        public string PlannedMaintenanceId { get; set; }
        public PlannedMaintenance PlannedMaintenance { get; set; }
        public string PartId { get; set; }
        public Part Part { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
        public bool IsDeleted { get; set; }
    }
}
