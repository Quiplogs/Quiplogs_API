using Quiplogs.Core.Data.Entities;
using Quiplogs.Inventory.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.WorkOrder.Data.Entities
{
    public class PlannedMaintenanceTaskDto : BaseEntity
    {
        public string PlannedMaintenanceId { get; set; }

        [ForeignKey("PlannedMaintenanceId")]
        public PlannedMaintenanceDto PlannedMaintenance { get; set; }
        public string TaskId { get; set; }

        [ForeignKey("TaskId")]
        public TaskDto Task { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Quantity { get; set; }

        public int UoM { get; set; }
        public bool IsDeleted { get; set; }
    }
}
