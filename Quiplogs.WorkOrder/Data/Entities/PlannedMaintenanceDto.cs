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

        public bool IsRecurring { get; set; }

        public decimal Interval { get; set; }

        public string UoM { get; set; }

        public IList<PlannedMaintenancePartDto> PlannedMaintenanceParts { get; set; }
    }
}
