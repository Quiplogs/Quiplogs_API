﻿using Quiplogs.WorkOrder.Dto.Requests.WorkOrderTask;
using Quiplogs.WorkOrder.Dto.Responses.WorkOrderTask;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.WorkOrderTask;
using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.UseCases.WorkOrderTask
{
    public class PutWorkOrderTaskUseCase : IPutWorkOrderTaskUseCase
    {
        private readonly IWorkOrderTaskRepository _repository;

        public PutWorkOrderTaskUseCase(IWorkOrderTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(PutWorkOrderTaskRequest message, IOutputPort<PutWorkOrderTaskResponse> outputPort)
        {
            var response = await _repository.Put(message.WorkOrderTask);
            if (response.Success)
            {
                outputPort.Handle(new PutWorkOrderTaskResponse(response.WorkOrderTask, true));
                return true;
            }

            outputPort.Handle(new PutWorkOrderTaskResponse(new[] { new Error("", "Error updating Work Order Task.") }));
            return false;
        }
    }
}
