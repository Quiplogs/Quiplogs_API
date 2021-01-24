using Api.Core;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.WorkOrderPart;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrderPart;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.UseCases.WorkOrderPart
{
    public class PutWorkOrderPartUseCase : IPutWorkOrderPartUseCase
    {
        private readonly IWorkOrderPartRepository _repository;

        public PutWorkOrderPartUseCase(IWorkOrderPartRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(PutWorkOrderPartRequest message, IOutputPort<PutWorkOrderPartResponse> outputPort)
        {
            var response = await _repository.Put(message.WorkOrderPart);
            if (response.Success)
            {
                outputPort.Handle(new PutWorkOrderPartResponse(response.WorkOrderPart, true));
                return true;
            }

            outputPort.Handle(new PutWorkOrderPartResponse(new[] { new Error("", "Error updating Work Order Part.") }));
            return false;
        }
    }
}
