using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrderPart
{
    public class ListWorkOrderPartRequest : IRequest<ListWorkOrderPartResponse>
    {
        public string CompanyId { get; }
        public string LocationId { get; }
        public string AssetId { get; }
        public string WorkOrderId { get; }
        public int PageNumber { get; }
        public ListWorkOrderPartRequest(string companyId, string locationId, string workOrderId, string assetId, int pageNumber)
        {
            CompanyId = companyId;
            LocationId = locationId;
            WorkOrderId = workOrderId;
            AssetId = assetId;
            PageNumber = pageNumber;
        }
    }
}
