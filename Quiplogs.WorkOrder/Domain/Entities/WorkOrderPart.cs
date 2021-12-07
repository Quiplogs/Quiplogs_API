using Quiplogs.Inventory.Domain.Entities;
using System;
using Quiplogs.Core.Domain.Entities;

namespace Quiplogs.WorkOrder.Domain.Entities
{
    public class WorkOrderPart : BaseEntity
    {
        public Guid WorkOrderId { get; set; }
        public WorkOrderEntity WorkOrder { get; set; }
        public Guid PartId { get; set; }
        public Part Part { get; set; }
        public decimal QuantityRequired { get; set; }
        public decimal QuantityUsed { get; set; }
        public string UoM { get; set; }
        public bool IsCompleted { get; set; }
    }
}
