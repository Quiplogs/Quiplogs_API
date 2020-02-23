using Quiplogs.Core.Data.Entities;
using Quiplogs.Inventory.Data.Entities;

namespace Quiplogs.WorkOrder.Data.Entities
{
    public class PlannedMaintenancePartDto : BaseEntity
    {
        public string PlannedMaintenanceId { get; set; }
        public PlannedMaintenanceDto PlannedMaintenance { get; set; }
        public string PartId { get; set; }
        public PartDto Part { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
    }
}
