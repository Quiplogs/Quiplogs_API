using System;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Inventory.Domain.Entities;

namespace Quiplogs.PlannedMaintenance.Domain.Entities
{
    public class PlannedMaintenancePart : BaseEntity
    {
        public Guid PlannedMaintenanceId { get; set; }
        public Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenance PlannedMaintenance { get; set; }
        public Guid PartId { get; set; }
        public Part Part { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
        public bool IsDeleted { get; set; }
    }
}
