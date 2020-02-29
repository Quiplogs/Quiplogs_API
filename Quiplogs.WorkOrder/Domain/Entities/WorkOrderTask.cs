using Api.Core.Domain.Entities;
using Quiplogs.Inventory.Domain.Entities;
using Quiplogs.WorkOrder.Domain.Entities;

namespace Quiplogs.WorkOrder.Domain.Entities
{
    public class WorkOrderTask : BaseEntity
    {
        public string WorkOrderId { get; set; }
        public WorkOrderEntity WorkOrder { get; set; }
        public string TaskId { get; set; }
        public TaskEntity Task { get; set; }
        public string TaskDescription { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
        public bool IsCompleted { get; set; }
    }
}
