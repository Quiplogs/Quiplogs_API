using Quiplogs.Inventory.Domain.Entities;
using System;
using Quiplogs.Core.Domain.Entities;

namespace Quiplogs.WorkOrder.Domain.Entities
{
    public class PlannedMaintenancePart : BaseEntity
    {
        public Guid PlannedMaintenanceId { get; set; }
        public PlannedMaintenance PlannedMaintenance { get; set; }
        public Guid PartId { get; set; }
        public Part Part { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
        public bool IsDeleted { get; set; }
    }
}
