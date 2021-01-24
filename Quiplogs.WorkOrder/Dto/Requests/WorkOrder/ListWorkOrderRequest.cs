using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrder;
using System;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrder
{
    public class ListWorkOrderRequest : IRequest<ListWorkOrderResponse>
    {
        public Guid CompanyId { get; }
        public Guid LocationId { get; }
        public Guid AssetId { get; set; }
        public int PageNumber { get; }
        public ListWorkOrderRequest(Guid companyId, Guid locationId, Guid assetId, int pageNumber)
        {
            CompanyId = companyId;
            LocationId = locationId;
            PageNumber = pageNumber;
            AssetId = assetId;
        }
    }
}
