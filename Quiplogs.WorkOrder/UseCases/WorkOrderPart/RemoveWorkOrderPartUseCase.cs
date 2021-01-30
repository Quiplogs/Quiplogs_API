using Quiplogs.WorkOrder.Dto.Requests.WorkOrderPart;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrderPart;
using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.UseCases.WorkOrderPart
{
    //public class RemoveWorkOrderPartUseCase : IRemoveWorkOrderPartUseCase
    //{
    //    private readonly IWorkOrderPartRepository _repository;

    //    public RemoveWorkOrderPartUseCase(IWorkOrderPartRepository repository)
    //    {
    //        _repository = repository;
    //    }

    //    public async Task<bool> Handle(RemoveWorkOrderPartRequest message, IOutputPort<RemoveWorkOrderPartResponse> outputPort)
    //    {
    //        var response = await _repository.Remove(message.Id);
    //        if (response.Success)
    //        {
    //            outputPort.Handle(new RemoveWorkOrderPartResponse(response.Description, true));
    //            return true;
    //        }

    //        outputPort.Handle(new RemoveWorkOrderPartResponse(new[] { new Error("", "Error removing Work Order Part.") }));
    //        return false;
    //    }
    //}
}
