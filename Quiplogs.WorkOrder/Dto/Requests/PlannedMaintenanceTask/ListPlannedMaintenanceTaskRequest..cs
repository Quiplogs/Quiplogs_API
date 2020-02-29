using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask;

namespace Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask
{
    public class ListPlannedMaintenanceTaskRequest : IRequest<ListPlannedMaintenanceTaskResponse>
    {
        public string CompanyId { get; }
        public string AssetId { get; }
        public string PlannedMaintenanceId { get; }
        public int PageNumber { get; }
        public ListPlannedMaintenanceTaskRequest(string companyId, string plannedMaintenanceId, string assetId, int pageNumber)
        {
            CompanyId = companyId;
            PlannedMaintenanceId = plannedMaintenanceId;
            AssetId = assetId;
            PageNumber = pageNumber;
        }
    }
}
