using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.Schedules.Data.Entities;
using System.Threading.Tasks;

namespace Quiplogs.Schedules.UseCases.ScheduleMonthly
{
    public class ListScheduleMonthlyUseCase : IListUseCase<Domain.Entities.ScheduleMonthly, ScheduleMonthlyDto>
    {
        private readonly IBaseRepository<Domain.Entities.ScheduleMonthly, ScheduleMonthlyDto> _baseRepository;

        public ListScheduleMonthlyUseCase(
            IBaseRepository<Domain.Entities.ScheduleMonthly, ScheduleMonthlyDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(ListRequest<Domain.Entities.ScheduleMonthly> request,
            IOutputPort<ListResponse<Domain.Entities.ScheduleMonthly>> outputPort)
        {
            var response = await _baseRepository.List(
                request.FilterParameters,
                model => model.PlannedMaintenanceId == request.ParentId);

            if (response.Success)
            {
                response.Models.ForEach(x => x.Type = "Monthly");
                outputPort.Handle(new ListResponse<Domain.Entities.ScheduleMonthly>(response.Models, true));
                return true;
            }

            outputPort.Handle(
                new ListResponse<Domain.Entities.ScheduleMonthly>(response.Errors));
            return false;
        }
    }
}
