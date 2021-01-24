using Api.Core;
using Api.Core.Dto;
using Api.Core.Interfaces;
using AutoMapper;
using Quiplogs.WorkOrder.Domain.Entities;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenancePart;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.UseCases.PlannedMaintenancePartPart
{
    public class PutPlannedMaintenancePartUseCase : IPutPlannedMaintenancePartUseCase
    {
        private readonly IPlannedMaintenancePartRepository _repository;
        private readonly IMapper _mapper;

        public PutPlannedMaintenancePartUseCase(IPlannedMaintenancePartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(PutPlannedMaintenancePartDtoRequest message, IOutputPort<PutPlannedMaintenancePartResponse> outputPort)
        {
            var model = _mapper.Map<PlannedMaintenancePart>(message);

            var response = await _repository.Put(model);
            if (response.Success)
            {
                outputPort.Handle(new PutPlannedMaintenancePartResponse(response.PlannedMaintenancePart, true));
                return true;
            }

            outputPort.Handle(new PutPlannedMaintenancePartResponse(new[] { new Error("", "Error updating Planned Maintenance Part.") }));
            return false;
        }
    }
}
