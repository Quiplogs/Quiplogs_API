using System;
using System.ComponentModel.DataAnnotations.Schema;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Inventory.Data.Entities;

namespace Quiplogs.PlannedMaintenance.Data.Entities
{
    public class PlannedMaintenancePartDto : BaseEntityDto
    {
        public Guid PlannedMaintenanceId { get; set; }

        [ForeignKey("PlannedMaintenanceId")]
        public PlannedMaintenanceDto PlannedMaintenance { get; set; }

        public Guid PartId { get; set; }

        [ForeignKey("PartId")]
        public PartDto Part { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
        public bool IsDeleted { get; set; }
    }
}
