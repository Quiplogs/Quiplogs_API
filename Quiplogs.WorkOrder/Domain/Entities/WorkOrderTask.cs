using Quiplogs.Core.Domain.Entities;
using System;

namespace Quiplogs.WorkOrder.Domain.Entities
{
    public class WorkOrderTask : BaseEntity
    {
        public Guid WorkOrderId { get; set; }
        public WorkOrderEntity WorkOrder { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal QuantityRequired { get; set; }
        public decimal QuantityUsed { get; set; }
        public string UoM { get; set; }
        public bool IsCompleted { get; set; }
    }
}
