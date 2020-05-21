using Quiplogs.Core.Data.Entities;
using Quiplogs.Inventory.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.WorkOrder.Data.Entities
{
    public class WorkOrderTaskDto : BaseEntity
    {
        public string WorkOrderId { get; set; }
        public WorkOrderDto WorkOrder { get; set; }
        public string TaskId { get; set; }
        public TaskDto Task { get; set; }
        public string TaskDescription { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Quantity { get; set; }
        public int UoM { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
