using Api.Core;
using Api.Core.Dto;
using Api.Core.Interfaces;
using AutoMapper;
using Quiplogs.Inventory.Dto.Requests.Task;
using Quiplogs.Inventory.Dto.Responses.Task;
using Quiplogs.Inventory.Interfaces.Repositories;
using Quiplogs.Inventory.Interfaces.UseCases.Task;
using System.Threading.Tasks;

namespace Quiplogs.Inventory.UseCases.Task
{
    public class PutTaskUseCase : IPutTaskUseCase
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _repository;

        public PutTaskUseCase(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(PutTaskRequest message, IOutputPort<PutTaskResponse> outputPort)
        {
            var mappedRequest = _mapper.Map<Domain.Entities.TaskEntity>(message);

            var response = await _repository.Put(mappedRequest);
            if (response.Success)
            {
                outputPort.Handle(new PutTaskResponse(response.Task, true));
                return true;
            }

            outputPort.Handle(new PutTaskResponse(new[] { new Error(GlobalVariables.error_taskFailure, "Error updating Task.") }));
            return false;
        }
    }
}