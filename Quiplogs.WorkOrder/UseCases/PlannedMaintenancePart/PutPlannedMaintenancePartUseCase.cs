using System.Threading.Tasks;
using AutoMapper;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenancePart;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenancePart;

namespace Quiplogs.WorkOrder.UseCases.PlannedMaintenancePart
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
            var model = _mapper.Map<Domain.Entities.PlannedMaintenancePart>(message);

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
