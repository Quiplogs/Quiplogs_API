using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderTask;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrderTask
{
    public class ListWorkOrderTaskRequest : IRequest<ListWorkOrderTaskResponse>
    {
        public string CompanyId { get; }
        public string LocationId { get; }
        public string AssetId { get; }
        public string WorkOrderId { get; }
        public int PageNumber { get; }
        public ListWorkOrderTaskRequest(string companyId, string locationId, string workOrderId, string assetId, int pageNumber)
        {
            CompanyId = companyId;
            LocationId = locationId;
            WorkOrderId = workOrderId;
            AssetId = assetId;
            PageNumber = pageNumber;
        }
    }
}
