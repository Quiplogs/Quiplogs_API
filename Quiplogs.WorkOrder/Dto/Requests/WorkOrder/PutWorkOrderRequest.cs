using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrder;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrder
{
    public class PutWorkOrderRequest : IRequest<PutWorkOrderResponse>
    {
        public Domain.Entities.WorkOrder WorkOrder { get; }
        public PutWorkOrderRequest(Domain.Entities.WorkOrder workOrder)
        {
            WorkOrder = workOrder;
        }
    }
}
