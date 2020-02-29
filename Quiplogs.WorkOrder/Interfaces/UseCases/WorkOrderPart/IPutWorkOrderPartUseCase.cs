using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.WorkOrderPart;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart;

namespace Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrderPart
{
    public interface IPutWorkOrderPartUseCase : IRequestHandler<PutWorkOrderPartRequest, PutWorkOrderPartResponse>
    {
    }
}
