using Api.Core.Domain.Entities;
using Quiplogs.Inventory.Domain.Entities;

namespace Quiplogs.WorkOrder.Domain.Entities
{
    public class PlannedMaintenanceTask : BaseEntity
    {
        public string PlannedMaintenanceId { get; set; }
        public PlannedMaintenanceEntity PlannedMaintenance { get; set; }
        public string TaskId { get; set; }
        public TaskEntity Task { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
        public bool IsDeleted { get; set; }
    }
}
