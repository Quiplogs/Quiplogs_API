﻿using Api.Core.Domain.Entities;
using Quiplogs.Inventory.Domain.Entities;
using Quiplogs.WorkOrder.Domain.Entities;
using System;

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
