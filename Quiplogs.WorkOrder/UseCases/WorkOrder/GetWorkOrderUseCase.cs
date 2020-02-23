using Api.Core;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.WorkOrder;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrder;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrder;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.UseCases.WorkOrder
{
    public class GetWorkOrderUseCase : IGetWorkOrderUseCase
    {
        private readonly IWorkOrderRepository _repository;

        public GetWorkOrderUseCase(IWorkOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(GetWorkOrderRequest message, IOutputPort<GetWorkOrderResponse> outputPort)
        {
            var response = await _repository.Get(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new GetWorkOrderResponse(response.WorkOrder, true));
                return true;
            }

            outputPort.Handle(new GetWorkOrderResponse(new[] { new Error(GlobalVariables.error_workOrderFailure, "WorkOrder not Found.") }));
            return false;
        }
    }
}
