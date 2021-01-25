using Quiplogs.WorkOrder.Dto.Responses.WorkOrder;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrder
{
    public class RemoveWorkOrderRequest : IRequest<RemoveWorkOrderResponse>
    {
        public Guid Id { get; }
        public RemoveWorkOrderRequest(Guid id)
        {
            Id = id;
        }
    }
}
