using Quiplogs.Assets.Data.Entities;
using Quiplogs.Core.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.WorkOrder.Data.Entities
{
    public class PlannedMaintenanceDto : BaseEntity
    {
        public string Name { get; set; }
        public string AssetId { get; set; }

        [ForeignKey("AssetId")]
        public AssetDto Asset { get; set; }

        public string CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public CompanyDto Company { get; set; }

        public string LocationId { get; set; }

        [ForeignKey("LocationId")]
        public LocationDto Location { get; set; }

        public string DefaultTechnicianId { get; set; }

        [ForeignKey("TechnicianId")]
        public UserEntity DefaultTechnician { get; set; }

        public string DefaultTechnicianName { get; set; }

        public string Notes { get; set; }

        public bool IsDeleted { get; set; }

        public string UoM { get; set; }

        public List<PlannedMaintenancePartDto> PlannedMaintenanceParts { get; set; }

        public List<PlannedMaintenanceTaskDto> PlannedMaintenanceTasks { get; set; }
    }
}
