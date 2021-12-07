using Quiplogs.Core.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.PlannedMaintenance.Data.Entities
{
    public class PlannedMaintenanceTaskDto : BaseEntityDto
    {
        public Guid PlannedMaintenanceId { get; set; }

        [ForeignKey("PlannedMaintenanceId")]
        public PlannedMaintenanceDto PlannedMaintenance { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal QuantityRequired { get; set; }
        public string UoM { get; set; }
        public bool IsDeleted { get; set; }
    }
}
