using Quiplogs.WorkOrder.Dto.Requests.WorkOrderPart;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderPart;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrderPart;
using System.Threading.Tasks;
using Quiplogs.Core.Domain;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.UseCases.WorkOrderPart
{
    //public class ListWorkOrderPartUseCase : IListWorkOrderPartUseCase
    //{
    //    private readonly IWorkOrderPartRepository _repository;

    //    public ListWorkOrderPartUseCase(IWorkOrderPartRepository repository)
    //    {
    //        _repository = repository;
    //    }

    //    public async Task<bool> Handle(ListWorkOrderPartRequest message, IOutputPort<ListWorkOrderPartResponse> outputPort)
    //    {
    //        //temp var
    //        var pageSize = 20;

    //        var response = await _repository.List(message.WorkOrderId, message.PageNumber, pageSize);
    //        if (response.Success)
    //        {
    //            var total = _repository.GetTotalRecords(message.WorkOrderId);
    //            var pagedResult = new PagedResult<Domain.Entities.WorkOrderPart>(response.WorkOrderParts, total, message.PageNumber, pageSize);

    //            outputPort.Handle(new ListWorkOrderPartResponse(pagedResult, true));
    //            return true;
    //        }

    //        outputPort.Handle(new ListWorkOrderPartResponse(new[] { new Error("", "No WorkOrder Parts Found.") }));
    //        return false;
    //    }
    //}
}
