using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance
{
    public class PutPlannedMaintenanceRequest : IRequest<PutPlannedMaintenanceResponse>
    {
        public string Name { get; set; }
        public string AssetId { get; set; }

        public string CompanyId { get; set; }

        public decimal Cycles { get; set; }

        public bool IsRecurring { get; set; }

        public int UoM { get; set; }

        public PutPlannedMaintenanceRequest(string name, string assetId, string companyId, decimal cycles, bool isRecurring, int uom)
        {
            Name = name;
            AssetId = assetId;
            CompanyId = companyId;
            Cycles = cycles;
            IsRecurring = isRecurring;
            UoM = uom;
        }
    }
}
