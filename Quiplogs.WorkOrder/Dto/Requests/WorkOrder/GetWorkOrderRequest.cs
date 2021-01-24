using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrder;
using System;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrder
{
    public class GetWorkOrderRequest : IRequest<GetWorkOrderResponse>
    {
        public Guid Id { get; }
        public GetWorkOrderRequest(Guid id)
        {
            Id = id;
        }
    }
}
