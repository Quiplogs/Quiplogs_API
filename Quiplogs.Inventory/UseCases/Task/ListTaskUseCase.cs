using Quiplogs.Inventory.Dto.Requests.Task;
using Quiplogs.Inventory.Dto.Responses.Task;
using System.Threading.Tasks;
using Quiplogs.Core.Domain;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;
using Quiplogs.Inventory.Interfces.Repositories;
using Quiplogs.Inventory.Interfces.UseCases.Task;

namespace Quiplogs.Inventory.UseCases.Task
{
    public class ListTaskUseCase : IListTaskUseCase
    {
        private readonly ITaskRepository _repository;

        public ListTaskUseCase(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ListTaskRequest message, IOutputPort<ListTaskResponse> outputPort)
        {
            //temp var
            var pageSize = 20;

            var response = await _repository.List(message.CompanyId, message.PageNumber, message.FilterName, pageSize);
            if (response.Success)
            {
                var total = await _repository.GetTotalRecords(message.CompanyId);
                var pagedResult = new PagedResult<Domain.Entities.TaskEntity>(response.Tasks, total, message.PageNumber, pageSize);

                outputPort.Handle(new ListTaskResponse(pagedResult, true));
                return true;
            }

            outputPort.Handle(new ListTaskResponse(new[] { new Error("", "No Tasks Found.") }));
            return false;
        }
    }
}
