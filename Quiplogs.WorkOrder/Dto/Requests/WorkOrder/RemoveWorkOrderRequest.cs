using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrder;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrder
{
    public class RemoveWorkOrderRequest : IRequest<RemoveWorkOrderResponse>
    {
        public string Id { get; }
        public RemoveWorkOrderRequest(string id)
        {
            Id = id;
        }
    }
}
