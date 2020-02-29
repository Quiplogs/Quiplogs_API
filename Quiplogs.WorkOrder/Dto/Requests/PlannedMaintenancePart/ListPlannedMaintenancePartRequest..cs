using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart
{
    public class ListPlannedMaintenancePartRequest : IRequest<ListPlannedMaintenancePartResponse>
    {
        public string CompanyId { get; }
        public string LocationId { get; }
        public string AssetId { get; }
        public string PlannedMaintenanceId { get; }
        public int PageNumber { get; }
        public ListPlannedMaintenancePartRequest(string companyId, string locationId, string plannedMaintenanceId, string assetId, int pageNumber)
        {
            CompanyId = companyId;
            LocationId = locationId;
            PlannedMaintenanceId = plannedMaintenanceId;
            AssetId = assetId;
            PageNumber = pageNumber;
        }
    }
}
