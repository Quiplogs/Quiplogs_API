using Quiplogs.Core.Data.Entities;
using Quiplogs.Inventory.Data.Entities;

namespace Quiplogs.Infrastructure.Data.Entities
{
    public class WorkOrderTaskDto : BaseEntity
    {
        public string WorkOrderId { get; set; }
        public WorkOrderDto WorkOrder { get; set; }
        public string TaskId { get; set; }
        public TaskDto Task { get; set; }
        public string TaskDescription { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
        public bool IsCompleted { get; set; }
    }
}
