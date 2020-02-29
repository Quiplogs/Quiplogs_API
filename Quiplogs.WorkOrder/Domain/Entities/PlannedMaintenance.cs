using Api.Core.Domain.Entities;
using Quiplogs.Assets.Domain.Entities;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Domain.Entities
{
    public class PlannedMaintenanceEntity : BaseEntity
    {
        public string AssetId { get; set; }

        public Asset Asset { get; set; }

        public string CompanyId { get; set; }

        public Company Company { get; set; }

        public string LocationId { get; set; }

        public Location Location { get; set; }

        public decimal Interval { get; set; }

        public string Notes { get; set; }

        public bool IsDeleted { get; set; }

        public string UoM { get; set; }

        public List<PlannedMaintenancePart> PlannedMaintenanceParts { get; set; }

        public List<PlannedMaintenanceTask> PlannedMaintenanceTasks { get; set; }
    }
}
