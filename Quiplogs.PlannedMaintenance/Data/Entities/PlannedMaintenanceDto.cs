using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Quiplogs.Assets.Data.Entities;
using Quiplogs.Core.Data.Entities;

namespace Quiplogs.PlannedMaintenance.Data.Entities
{
    public class PlannedMaintenanceDto : BaseLocationDto
    {
        public string Name { get; set; }
        public Guid AssetId { get; set; }

        [ForeignKey("AssetId")]
        public AssetDto Asset { get; set; }
        public Guid DefaultTechnicianId { get; set; }

        [ForeignKey("DefaultTechnicianId")]
        public UserEntity DefaultTechnician { get; set; }
        public string Notes { get; set; }
        public bool IsDeleted { get; set; }
        public List<PlannedMaintenancePartDto> PlannedMaintenanceParts { get; set; }
        public List<PlannedMaintenanceTaskDto> PlannedMaintenanceTasks { get; set; }
    }
}
