using AutoMapper;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenanceTask;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenanceTask;
using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.WorkOrder.UseCases.PlannedMaintenanceTask
{
    public class PutPlannedMaintenanceTaskUseCase : IPutPlannedMaintenanceTaskUseCase
    {
        private readonly IPlannedMaintenanceTaskRepository _repository;
        private readonly IMapper _mapper;

        public PutPlannedMaintenanceTaskUseCase(IPlannedMaintenanceTaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(PutPlannedMaintenanceTaskRequest message, IOutputPort<PutPlannedMaintenanceTaskResponse> outputPort)
        {
            var model = _mapper.Map<Domain.Entities.PlannedMaintenanceTask>(message);

            var response = await _repository.Put(model);
            if (response.Success)
            {
                outputPort.Handle(new PutPlannedMaintenanceTaskResponse(response.PlannedMaintenanceTask, true));
                return true;
            }

            outputPort.Handle(new PutPlannedMaintenanceTaskResponse(new[] { new Error("", "Error updating Planned Maintenance Task.") }));
            return false;
        }
    }
}
