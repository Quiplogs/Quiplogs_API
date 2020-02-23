using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.WorkOrder;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrder;

namespace Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrder
{
    public interface IGetWorkOrderUseCase : IRequestHandler<GetWorkOrderRequest, GetWorkOrderResponse>
    {
    }
}
