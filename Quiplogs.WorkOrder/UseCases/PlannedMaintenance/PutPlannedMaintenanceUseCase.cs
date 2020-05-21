using Api.Core;
using Api.Core.Dto;
using Api.Core.Interfaces;
using AutoMapper;
using Quiplogs.PlannedMaintenance.Interfaces.UseCases.PlannedMaintenance;
using Quiplogs.WorkOrder.Domain.Entities;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.UseCases.PlannedMaintenance
{
    public class PutPlannedMaintenanceUseCase : IPutPlannedMaintenanceUseCase
    {
        private readonly IPlannedMaintenanceRepository _repository;
        private readonly IMapper _mapper;

        public PutPlannedMaintenanceUseCase(IPlannedMaintenanceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(PutPlannedMaintenanceRequest message, IOutputPort<PutPlannedMaintenanceResponse> outputPort)
        {
            var model = _mapper.Map<PlannedMaintenanceEntity>(message);

            var response = await _repository.Put(model);
            if (response.Success)
            {
                outputPort.Handle(new PutPlannedMaintenanceResponse(response.PlannedMaintenance, true));
                return true;
            }

            outputPort.Handle(new PutPlannedMaintenanceResponse(new[] { new Error(GlobalVariables.error_plannedMaintenanceFailure, "Error updating PlannedMaintenance.") }));
            return false;
        }
    }
}
