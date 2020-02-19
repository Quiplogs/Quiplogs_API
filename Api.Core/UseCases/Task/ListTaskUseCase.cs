using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Dto.Requests.Task;
using Api.Core.Dto.Responses.Task;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Task;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Task
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

            var response = await _repository.List(message.CompanyId, message.PageNumber, pageSize);
            if (response.Success)
            {
                var total = await _repository.GetTotalRecords(message.CompanyId);
                var pagedResult = new PagedResult<Domain.Entities.TaskEntity>(response.Tasks, total, message.PageNumber, pageSize);

                outputPort.Handle(new ListTaskResponse(pagedResult, true));
                return true;
            }

            outputPort.Handle(new ListTaskResponse(new[] { new Error(GlobalVariables.error_taskFailure, "No Tasks Found.") }));
            return false;
        }
    }
}
