using System;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Inventory.Domain.Entities;

namespace Quiplogs.PlannedMaintenance.Domain.Entities
{
    public class PlannedMaintenanceTask : BaseEntity
    {
        public Guid PlannedMaintenanceId { get; set; }
        public Quiplogs.PlannedMaintenance.Domain.Entities.PlannedMaintenance PlannedMaintenance { get; set; }
        public Guid TaskId { get; set; }
        public TaskEntity Task { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
        public bool IsDeleted { get; set; }
    }
}
