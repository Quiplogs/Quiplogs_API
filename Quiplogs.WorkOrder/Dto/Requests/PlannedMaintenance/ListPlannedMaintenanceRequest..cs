using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance
{
    public class ListPlannedMaintenanceRequest : IRequest<ListPlannedMaintenanceResponse>
    {
        public Guid CompanyId { get; }
        public Guid LocationId { get; }
        public Guid AssetId { get; }
        public int PageNumber { get; }
        public bool ShouldPage { get; set; }
        public ListPlannedMaintenanceRequest(Guid companyId, Guid locationId, Guid assetId, bool shouldPage, int pageNumber)
        {
            CompanyId = companyId;
            LocationId = locationId;
            AssetId = assetId;
            ShouldPage = shouldPage;
            PageNumber = pageNumber;
        }
    }
}
