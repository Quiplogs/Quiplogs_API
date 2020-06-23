using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart
{
    public class PutPlannedMaintenancePartDtoRequest : IRequest<PutPlannedMaintenancePartResponse>
    {
        public string CompanyId { get; set; }
        public string PlannedMaintenanceId { get; set; }
        public string PartId { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }

        public PutPlannedMaintenancePartDtoRequest(string companyId, string plannedMaintenanceId, string partId, decimal quantity, string uom)
        {
            CompanyId = companyId;
            PlannedMaintenanceId = plannedMaintenanceId;
            PartId = partId;
            Quantity = quantity;
            UoM = uom;
        }
    }
}
