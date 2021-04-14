using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.PlannedMaintenance.Data.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Quiplogs.PlannedMaintenance.UseCases.PlannedMaintenance
{
    public class PutPlannedMaintenanceUseCase : IPutUseCase<Domain.Entities.PlannedMaintenance, PlannedMaintenanceDto>
    {
        private readonly IBaseRepository<Domain.Entities.PlannedMaintenance, PlannedMaintenanceDto> _baseRepository;

        public PutPlannedMaintenanceUseCase(IBaseRepository<Domain.Entities.PlannedMaintenance, PlannedMaintenanceDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(PutRequest<Domain.Entities.PlannedMaintenance> request, IOutputPort<PutResponse<Domain.Entities.PlannedMaintenance>> outputPort)
        {
            var response = await _baseRepository.Put(request.Model);

            if (response.Success)
            {
                var getResponse = await _baseRepository.GetById(response.Model.Id, 
                    including: source => source.Include(x => x.Asset)
                        .Include(x => x.DefaultTechnician)
                        .Include(x => x.Location));

                outputPort.Handle(new PutResponse<Domain.Entities.PlannedMaintenance>(getResponse.Model, true));
                return true;
            }

            outputPort.Handle(new PutResponse<Domain.Entities.PlannedMaintenance>(response.Errors));
            return false;
        }
    }
}
