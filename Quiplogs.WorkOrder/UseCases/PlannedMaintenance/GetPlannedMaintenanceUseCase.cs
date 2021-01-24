using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using Quiplogs.WorkOrder.Interfaces.UseCases.PlannedMaintenance;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.UseCases.PlannedMaintenance
{
    public class GetPlannedMaintenanceUseCase : IGetPlannedMaintenanceUseCase
    {
        private readonly IPlannedMaintenanceRepository _repository;

        public GetPlannedMaintenanceUseCase(IPlannedMaintenanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(GetPlannedMaintenanceRequest message, IOutputPort<GetPlannedMaintenanceResponse> outputPort)
        {
            var response = await _repository.Get(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new GetPlannedMaintenanceResponse(response.PlannedMaintenance, true));
                return true;
            }

            outputPort.Handle(new GetPlannedMaintenanceResponse(new[] { new Error("", "Planned Maintenance not Found.") }));
            return false;
        }
    }
}
