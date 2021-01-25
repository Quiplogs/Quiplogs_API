using Quiplogs.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.WorkOrderTask;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderTask;

namespace Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrderTask
{
    public interface IPutWorkOrderTaskUseCase : IRequestHandler<PutWorkOrderTaskRequest, PutWorkOrderTaskResponse>
    {
    }
}
