using Api.Core;
using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.WorkOrderTask;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderTask;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrderTask;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.UseCases.WorkOrderTask
{
    public class ListWorkOrderTaskUseCase : IListWorkOrderTaskUseCase
    {
        private readonly IWorkOrderTaskRepository _repository;

        public ListWorkOrderTaskUseCase(IWorkOrderTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ListWorkOrderTaskRequest message, IOutputPort<ListWorkOrderTaskResponse> outputPort)
        {
            //temp var
            var pageSize = 20;

            var response = await _repository.List(message.WorkOrderId, message.PageNumber, pageSize);
            if (response.Success)
            {
                var total = _repository.GetTotalRecords(message.WorkOrderId);
                var pagedResult = new PagedResult<Domain.Entities.WorkOrderTask>(response.WorkOrderTasks, total, message.PageNumber, pageSize);

                outputPort.Handle(new ListWorkOrderTaskResponse(pagedResult, true));
                return true;
            }

            outputPort.Handle(new ListWorkOrderTaskResponse(new[] { new Error("", "No WorkOrder Tasks Found.") }));
            return false;
        }
    }
}
