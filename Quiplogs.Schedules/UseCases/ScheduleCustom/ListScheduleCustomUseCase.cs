using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.Schedules.Data.Entities;
using System.Threading.Tasks;

namespace Quiplogs.Schedules.UseCases.ScheduleCustom
{
    public class ListScheduleCustomUseCase : IListUseCase<Domain.Entities.ScheduleCustom, ScheduleCustomDto>
    {
        private readonly IBaseRepository<Domain.Entities.ScheduleCustom, ScheduleCustomDto> _baseRepository;

        public ListScheduleCustomUseCase(IBaseRepository<Domain.Entities.ScheduleCustom, ScheduleCustomDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(ListRequest<Domain.Entities.ScheduleCustom> request, IOutputPort<ListResponse<Domain.Entities.ScheduleCustom>> outputPort)
        {
            var response = await _baseRepository.List(
                request.CompanyId,
                model => model.PlannedMaintenanceId == request.ParentId && model.CompanyId == request.CompanyId,
                request.FilterParameters);

            if (response.Success)
            {
                response.Models.ForEach(x => x.Type = "Custom");
                outputPort.Handle(new ListResponse<Domain.Entities.ScheduleCustom>(response.Models, true));
                return true;
            }

            outputPort.Handle(new ListResponse<Domain.Entities.ScheduleCustom>(response.Errors));
            return false;
        }
    }
}
