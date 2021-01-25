using Quiplogs.Assets.Data.Entities;
using Quiplogs.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.WorkOrder.Data.Entities
{
    public class PlannedMaintenanceDto : BaseLocationDto

    {
        public string Name { get; set; }
        public Guid AssetId { get; set; }

        [ForeignKey("AssetId")]
        public AssetDto Asset { get; set; }

        public Guid DefaultTechnicianId { get; set; }

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
