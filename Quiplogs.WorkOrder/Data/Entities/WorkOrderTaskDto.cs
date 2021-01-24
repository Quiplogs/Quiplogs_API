﻿using Quiplogs.Core.Data.Entities;
using Quiplogs.Inventory.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.WorkOrder.Data.Entities
{
    public class WorkOrderTaskDto : BaseEntityDto
    {
        public Guid WorkOrderId { get; set; }

        [ForeignKey("WorkOrderId")]
        public WorkOrderDto WorkOrder { get; set; }
        public Guid TaskId { get; set; }

        [ForeignKey("TaskId")]
        public TaskDto Task { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal QuantityRequired { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal QuantityUsed { get; set; }
        public string UoM { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
