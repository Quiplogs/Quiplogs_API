using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;
using System;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart
{
    public class PutPlannedMaintenancePartDtoRequest : IRequest<PutPlannedMaintenancePartResponse>
    {
        public Guid CompanyId { get; set; }
        public Guid PlannedMaintenanceId { get; set; }
        public Guid PartId { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }

        public PutPlannedMaintenancePartDtoRequest(Guid companyId, Guid plannedMaintenanceId, Guid partId, decimal quantity, string uom)
        {
            CompanyId = companyId;
            PlannedMaintenanceId = plannedMaintenanceId;
            PartId = partId;
            Quantity = quantity;
            UoM = uom;
        }
    }
}
