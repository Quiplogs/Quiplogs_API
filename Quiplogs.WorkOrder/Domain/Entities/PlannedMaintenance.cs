using Api.Core.Domain.Entities;
using Quiplogs.Assets.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Domain.Entities
{
    public class PlannedMaintenanceEntity : BaseEntity
    {
        public string Name { get; set; }

        public Guid AssetId { get; set; }

        public Asset Asset { get; set; }

        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

        public Guid LocationId { get; set; }

        public Location Location { get; set; }

        public Guid DefaultTechnicianId { get; set; }

        public AppUser DefaultTechnician { get; set; }

        public string DefaultTechnicianName { get; set; }

        public string Notes { get; set; }

        public bool IsDeleted { get; set; }

        public string UoM { get; set; }

        public List<PlannedMaintenancePart> PlannedMaintenanceParts { get; set; }

        public List<PlannedMaintenanceTask> PlannedMaintenanceTasks { get; set; }
    }
}
