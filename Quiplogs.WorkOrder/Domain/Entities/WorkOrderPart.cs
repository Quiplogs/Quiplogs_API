﻿using Api.Core.Domain.Entities;
using Quiplogs.Inventory.Domain.Entities;

namespace Quiplogs.WorkOrder.Domain.Entities
{
    public class WorkOrderPart : BaseEntity
    {
        public string WorkOrderId { get; set; }
        public WorkOrderEntity WorkOrder { get; set; }
        public string PartId { get; set; }
        public Part Part { get; set; }
        public string PartCode { get; set; }
        public string PartDescription { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
        public bool IsCompleted { get; set; }
    }
}