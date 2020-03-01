using Quiplogs.WorkOrder.Domain.Entities;

namespace Api.UseCases.PlannedMaintenance.Put
{
    public class PutPlannedMaintenanceRequest
    {
        public PlannedMaintenanceEntity PlannedMaintenance { get; set; }
    }
}
