using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.Schedules.Data.Entities;
using System.Threading.Tasks;

namespace Quiplogs.Schedules.UseCases.ScheduleWeekly
{
    public class ListScheduleWeeklyUseCase : IListUseCase<Domain.Entities.ScheduleWeekly, ScheduleWeeklyDto>
    {
        private readonly IBaseRepository<Domain.Entities.ScheduleWeekly, ScheduleWeeklyDto> _baseRepository;

        public ListScheduleWeeklyUseCase(
            IBaseRepository<Domain.Entities.ScheduleWeekly, ScheduleWeeklyDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(ListRequest<Domain.Entities.ScheduleWeekly> request,
            IOutputPort<ListResponse<Domain.Entities.ScheduleWeekly>> outputPort)
        {
            var response = await _baseRepository.List(
                request.FilterParameters,
                model => model.PlannedMaintenanceId == request.ParentId);

            if (response.Success)
            {
                response.Models.ForEach(x => x.Type = "Weekly");
                outputPort.Handle(new ListResponse<Domain.Entities.ScheduleWeekly>(response.Models, true));
                return true;
            }

            outputPort.Handle(
                new ListResponse<Domain.Entities.ScheduleWeekly>(response.Errors));
            return false;
        }
    }
}
