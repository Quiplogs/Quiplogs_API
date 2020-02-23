using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrder;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrder
{
    public class ListWorkOrderRequest : IRequest<ListWorkOrderResponse>
    {
        public string CompanyId { get; }
        public string LocationId { get; }
        public int PageNumber { get; }
        public ListWorkOrderRequest(string companyId, string locationId, int pageNumber)
        {
            CompanyId = companyId;
            LocationId = locationId;
            PageNumber = pageNumber;
        }
    }
}
