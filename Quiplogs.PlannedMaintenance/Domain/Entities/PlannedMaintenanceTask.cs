using System;
using Quiplogs.Core.Domain.Entities;

namespace Quiplogs.PlannedMaintenance.Domain.Entities
{
    public class PlannedMaintenanceTask : BaseEntity
    {
        public Guid PlannedMaintenanceId { get; set; }
        public PlannedMaintenance PlannedMaintenance { get; set; }
        public string Description { get; set; }
        public decimal QuantityRequired { get; set; }
        public string UoM { get; set; }
        public bool IsDeleted { get; set; }
    }
}
