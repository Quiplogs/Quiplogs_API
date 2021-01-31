using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.PlannedMaintenance.Data.Entities;

namespace Quiplogs.PlannedMaintenance.UseCases.PlannedMaintenanceTask
{
    public class ListPlannedMaintenanceTaskUseCase : IListUseCase<Domain.Entities.PlannedMaintenanceTask, PlannedMaintenanceTaskDto>
    {
        private readonly IBaseRepository<Domain.Entities.PlannedMaintenanceTask, PlannedMaintenanceTaskDto> _baseRepository;

        public ListPlannedMaintenanceTaskUseCase(IBaseRepository<Domain.Entities.PlannedMaintenanceTask, PlannedMaintenanceTaskDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(ListRequest<Domain.Entities.PlannedMaintenanceTask> request, IOutputPort<ListResponse<Domain.Entities.PlannedMaintenanceTask>> outputPort)
        {
            var response = await _baseRepository.List(
                request.FilterParameters,
                model => model.PlannedMaintenanceId == request.ParentId);

            if (response.Success)
            {
                outputPort.Handle(new ListResponse<Domain.Entities.PlannedMaintenanceTask>(response.Models, true));
                return true;
            }

            outputPort.Handle(new ListResponse<Domain.Entities.PlannedMaintenanceTask>(new[] { new Error("", "Model not Found.") }));
            return false;
        }
    }
}
