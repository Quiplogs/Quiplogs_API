using Api.Core.Domain.Entities;
using Quiplogs.Inventory.Domain.Entities;
using System;

namespace Quiplogs.WorkOrder.Domain.Entities
{
    public class PlannedMaintenanceTask : BaseEntity
    {
        public Guid PlannedMaintenanceId { get; set; }
        public PlannedMaintenanceEntity PlannedMaintenance { get; set; }
        public Guid TaskId { get; set; }
        public TaskEntity Task { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
        public bool IsDeleted { get; set; }
    }
}
