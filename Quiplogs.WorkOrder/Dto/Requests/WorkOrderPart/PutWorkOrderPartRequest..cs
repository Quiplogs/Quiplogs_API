using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrderPart
{
    public class PutWorkOrderPartRequest : IRequest<PutWorkOrderPartResponse>
    {
        public Domain.Entities.WorkOrderPart WorkOrderPart { get; }
        public PutWorkOrderPartRequest(Domain.Entities.WorkOrderPart workOrderPart)
        {
            WorkOrderPart = workOrderPart;
        }
    }
}
