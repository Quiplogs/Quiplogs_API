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
    public class PutWorkOrderUseCase : IPutWorkOrderUseCase
    {
        private readonly IWorkOrderRepository _repository;

        public PutWorkOrderUseCase(IWorkOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(PutWorkOrderRequest message, IOutputPort<PutWorkOrderResponse> outputPort)
        {
            var response = await _repository.Put(message.WorkOrder);
            if (response.Success)
            {
                outputPort.Handle(new PutWorkOrderResponse(response.WorkOrder, true));
                return true;
            }

            outputPort.Handle(new PutWorkOrderResponse(new[] { new Error("", "Error updating WorkOrder.") }));
            return false;
        }
    }
}
