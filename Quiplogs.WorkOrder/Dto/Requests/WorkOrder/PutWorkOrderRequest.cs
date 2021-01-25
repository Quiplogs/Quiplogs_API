using Quiplogs.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrder;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrder
{
    public class PutWorkOrderRequest : IRequest<PutWorkOrderResponse>
    {
        public Domain.Entities.WorkOrderEntity WorkOrder { get; }
        public PutWorkOrderRequest(Domain.Entities.WorkOrderEntity workOrder)
        {
            WorkOrder = workOrder;
        }
    }
}
