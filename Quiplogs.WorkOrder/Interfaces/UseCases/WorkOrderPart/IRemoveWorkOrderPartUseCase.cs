using Quiplogs.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.WorkOrderPart;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart;

namespace Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrderPart
{
    public interface IRemoveWorkOrderPartUseCase : IRequestHandler<RemoveWorkOrderPartRequest, RemoveWorkOrderPartResponse>
    {
    }
}
