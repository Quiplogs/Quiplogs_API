using Quiplogs.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderTask;

namespace Quiplogs.WorkOrder.Dto.Requests.WorkOrderTask
{
    public class PutWorkOrderTaskRequest : IRequest<PutWorkOrderTaskResponse>
    {
        public Domain.Entities.WorkOrderTask WorkOrderTask { get; }
        public PutWorkOrderTaskRequest(Domain.Entities.WorkOrderTask workOrderTask)
        {
            WorkOrderTask = workOrderTask;
        }
    }
}
