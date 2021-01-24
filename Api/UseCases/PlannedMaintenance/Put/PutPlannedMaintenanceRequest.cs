using System;

namespace Api.UseCases.PlannedMaintenance.Put
{
    public class PutPlannedMaintenanceRequest
    {
        public Guid AssetId { get; set; }

        public string Name { get; set; }

        public Guid CompanyId { get; set; }

        public decimal Cycles { get; set; }

        public bool IsRecurring { get; set; }

        public int UoM { get; set; }
    }
}
