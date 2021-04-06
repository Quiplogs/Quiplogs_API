using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.Schedules.Data.Entities;
using System.Threading.Tasks;

namespace Quiplogs.Schedules.UseCases.ScheduleDaily
{
    public class ListScheduleDailyUseCase : IListUseCase<Domain.Entities.ScheduleDaily, ScheduleDailyDto>
    {
        private readonly IBaseRepository<Domain.Entities.ScheduleDaily, ScheduleDailyDto> _baseRepository;

        public ListScheduleDailyUseCase(IBaseRepository<Domain.Entities.ScheduleDaily, ScheduleDailyDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(ListRequest<Domain.Entities.ScheduleDaily> request, IOutputPort<ListResponse<Domain.Entities.ScheduleDaily>> outputPort)
        {
            var response = await _baseRepository.List(
                request.FilterParameters,
                model => model.PlannedMaintenanceId == request.ParentId);

            if (response.Success)
            {
                response.Models.ForEach(x => x.Type = "Daily");
                outputPort.Handle(new ListResponse<Domain.Entities.ScheduleDaily>(response.Models, true));
                return true;
            }

            outputPort.Handle(new ListResponse<Domain.Entities.ScheduleDaily>(response.Errors));
            return false;
        }
    }
}
