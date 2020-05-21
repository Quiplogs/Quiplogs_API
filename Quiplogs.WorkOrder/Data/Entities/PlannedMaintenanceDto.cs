using Quiplogs.Assets.Data.Entities;
using Quiplogs.Core.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.WorkOrder.Data.Entities
{
    public class PlannedMaintenanceDto : BaseEntity
    {
        public string AssetId { get; set; }

        [ForeignKey("AssetId")]
        public AssetDto Asset { get; set; }

        public string CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public CompanyDto Company { get; set; }

        public string LocationId { get; set; }

        [ForeignKey("LocationId")]
        public LocationDto Location { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Cycle { get; set; }

        public bool IsRecurring { get; set; }

        public string Notes { get; set; }

        public bool IsDeleted { get; set; }

        public int UoM { get; set; }

        public List<PlannedMaintenancePartDto> PlannedMaintenanceParts { get; set; }

        public List<PlannedMaintenanceTaskDto> PlannedMaintenanceTasks { get; set; }
    }
}
