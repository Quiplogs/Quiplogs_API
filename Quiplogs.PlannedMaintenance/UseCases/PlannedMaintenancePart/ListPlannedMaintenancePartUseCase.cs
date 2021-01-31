using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.PlannedMaintenance.Data.Entities;

namespace Quiplogs.PlannedMaintenance.UseCases.PlannedMaintenancePart
{
    public class ListPlannedMaintenancePartUseCase : IListUseCase<Domain.Entities.PlannedMaintenancePart, PlannedMaintenancePartDto>
    {
        private readonly IBaseRepository<Domain.Entities.PlannedMaintenancePart, PlannedMaintenancePartDto> _baseRepository;

        public ListPlannedMaintenancePartUseCase(IBaseRepository<Domain.Entities.PlannedMaintenancePart, PlannedMaintenancePartDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(ListRequest<Domain.Entities.PlannedMaintenancePart> request, IOutputPort<ListResponse<Domain.Entities.PlannedMaintenancePart>> outputPort)
        {
            var response = await _baseRepository.List(
                request.FilterParameters,
                model => model.PlannedMaintenanceId == request.ParentId);

            if (response.Success)
            {
                outputPort.Handle(new ListResponse<Domain.Entities.PlannedMaintenancePart>(response.Models, true));
                return true;
            }

            outputPort.Handle(new ListResponse<Domain.Entities.PlannedMaintenancePart>(new[] { new Error("", "Model not Found.") }));
            return false;
        }
    }
}
