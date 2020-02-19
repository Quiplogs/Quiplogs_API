﻿using Api.Core.Dto;
using Api.Core.Dto.Requests.Task;
using Api.Core.Dto.Responses.Task;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Task;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Task
{
    public class RemoveTaskUseCase : IRemoveTaskUseCase
    {
        private readonly ITaskRepository _repository;

        public RemoveTaskUseCase(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemoveTaskRequest message, IOutputPort<RemoveTaskResponse> outputPort)
        {
            var response = await _repository.Remove(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new RemoveTaskResponse(response.Description, true));
                return true;
            }

            outputPort.Handle(new RemoveTaskResponse(new[] { new Error(GlobalVariables.error_taskFailure, "Error removing Task.") }));
            return false;
        }
    }
}
