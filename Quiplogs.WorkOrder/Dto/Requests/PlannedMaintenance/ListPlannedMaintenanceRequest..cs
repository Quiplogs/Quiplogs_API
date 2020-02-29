using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance
{
    public class ListPlannedMaintenanceRequest : IRequest<ListPlannedMaintenanceResponse>
    {
        public string CompanyId { get; }
        public string LocationId { get; }
        public string AssetId { get; }
        public int PageNumber { get; }
        public ListPlannedMaintenanceRequest(string companyId, string locationId, string assetId, int pageNumber)
        {
            CompanyId = companyId;
            LocationId = locationId;
            AssetId = assetId;
            PageNumber = pageNumber;
        }
    }
}
