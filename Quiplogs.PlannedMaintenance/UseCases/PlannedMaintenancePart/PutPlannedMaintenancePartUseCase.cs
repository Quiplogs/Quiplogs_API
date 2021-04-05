using Microsoft.EntityFrameworkCore;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.PlannedMaintenance.Data.Entities;
using System.Threading.Tasks;

namespace Quiplogs.PlannedMaintenance.UseCases.PlannedMaintenancePart
{
    public class PutPlannedMaintenancePartUseCase : IPutUseCase<Domain.Entities.PlannedMaintenancePart, PlannedMaintenancePartDto>
    {
        private readonly IBaseRepository<Domain.Entities.PlannedMaintenancePart, PlannedMaintenancePartDto> _baseRepository;

        public PutPlannedMaintenancePartUseCase(
            IBaseRepository<Domain.Entities.PlannedMaintenancePart,
                PlannedMaintenancePartDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(PutRequest<Domain.Entities.PlannedMaintenancePart> request, IOutputPort<PutResponse<Domain.Entities.PlannedMaintenancePart>> outputPort)
        {
            request.Model.Company = null;
            request.Model.Part = null;
            request.Model.PlannedMaintenance = null;

            var response = await _baseRepository.Put(request.Model);
            if (response.Success)
            {
                var updatedModelResponse = await _baseRepository.GetById(request.Model.Id, including: source => source.Include(model => model.Part));
                outputPort.Handle(new PutResponse<Domain.Entities.PlannedMaintenancePart>(updatedModelResponse.Model, true));
                return true;
            }

            outputPort.Handle(new PutResponse<Domain.Entities.PlannedMaintenancePart>(response.Errors));
            return false;
        }
    }
}
