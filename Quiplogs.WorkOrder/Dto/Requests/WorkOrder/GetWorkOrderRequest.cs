using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrder;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrder
{
    public class GetWorkOrderRequest : IRequest<GetWorkOrderResponse>
    {
        public string Id { get; }
        public GetWorkOrderRequest(string id)
        {
            Id = id;
        }
    }
}
