using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.PlannedMaintenance.Interfaces.UseCases.PlannedMaintenance;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenance;
using Quiplogs.WorkOrder.Dto.Responses.PlannedMaintenance;
using Quiplogs.WorkOrder.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.UseCases.PlannedMaintenance
{
    public class ListPlannedMaintenanceUseCase : IListPlannedMaintenanceUseCase
    {
        private readonly IPlannedMaintenanceRepository _repository;

        public ListPlannedMaintenanceUseCase(IPlannedMaintenanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ListPlannedMaintenanceRequest message, IOutputPort<ListPlannedMaintenanceResponse> outputPort)
        {
            //temp var
            var pageSize = 20;

            var response = await _repository.List(message.CompanyId, message.LocationId, message.AssetId, message.PageNumber, pageSize, message.ShouldPage);
            if (response.Success)
            {
                var total = await _repository.GetTotalRecords(message.CompanyId);
                var pagedResult = new PagedResult<Domain.Entities.PlannedMaintenanceEntity>(response.PlannedMaintenances, total, message.PageNumber, pageSize);

                outputPort.Handle(new ListPlannedMaintenanceResponse(pagedResult, true));
                return true;
            }

            outputPort.Handle(new ListPlannedMaintenanceResponse(new[] { new Error("", "No Planned Maintenances Found.") }));
            return false;
        }
    }
}
