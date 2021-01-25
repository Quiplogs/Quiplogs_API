using Quiplogs.Inventory.Domain.Entities;
using System;
using Quiplogs.Core.Domain.Entities;

namespace Quiplogs.WorkOrder.Domain.Entities
{
    public class WorkOrderTask : BaseEntity
    {
        public Guid WorkOrderId { get; set; }
        public WorkOrderEntity WorkOrder { get; set; }
        public Guid TaskId { get; set; }
        public TaskEntity Task { get; set; }
        public string TaskDescription { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
        public bool IsCompleted { get; set; }
    }
}
