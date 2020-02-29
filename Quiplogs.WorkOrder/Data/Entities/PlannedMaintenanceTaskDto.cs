using Quiplogs.Core.Data.Entities;
using Quiplogs.Inventory.Data.Entities;

namespace Quiplogs.WorkOrder.Data.Entities
{
    public class PlannedMaintenanceTaskDto : BaseEntity
    {
        public string PlannedMaintenanceId { get; set; }
        public PlannedMaintenanceDto PlannedMaintenance { get; set; }
        public string TaskId { get; set; }
        public TaskDto Task { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
        public bool IsDeleted { get; set; }
    }
}
