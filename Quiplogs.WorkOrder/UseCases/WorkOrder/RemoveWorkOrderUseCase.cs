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
    public class RemoveWorkOrderUseCase : IRemoveWorkOrderUseCase
    {
        private readonly IWorkOrderRepository _repository;

        public RemoveWorkOrderUseCase(IWorkOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemoveWorkOrderRequest message, IOutputPort<RemoveWorkOrderResponse> outputPort)
        {
            var response = await _repository.Remove(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new RemoveWorkOrderResponse(response.Description, true));
                return true;
            }

            outputPort.Handle(new RemoveWorkOrderResponse(new[] { new Error("", "Error removing WorkOrder.") }));
            return false;
        }
    }
}
