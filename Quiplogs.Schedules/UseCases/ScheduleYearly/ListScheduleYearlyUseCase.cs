using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.Schedules.Data.Entities;
using System.Threading.Tasks;

namespace Quiplogs.Schedules.UseCases.ScheduleYearly
{
    public class ListScheduleYearlyUseCase : IListUseCase<Domain.Entities.ScheduleYearly, ScheduleYearlyDto>
    {
        private readonly IBaseRepository<Domain.Entities.ScheduleYearly, ScheduleYearlyDto> _baseRepository;

        public ListScheduleYearlyUseCase(
            IBaseRepository<Domain.Entities.ScheduleYearly, ScheduleYearlyDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(ListRequest<Domain.Entities.ScheduleYearly> request,
            IOutputPort<ListResponse<Domain.Entities.ScheduleYearly>> outputPort)
        {
            var response = await _baseRepository.List(
                request.FilterParameters,
                model => model.PlannedMaintenanceId == request.ParentId);

            if (response.Success)
            {
                response.Models.ForEach(x => x.Type = "Yearly");
                outputPort.Handle(new ListResponse<Domain.Entities.ScheduleYearly>(response.Models, true));
                return true;
            }

            outputPort.Handle(
                new ListResponse<Domain.Entities.ScheduleYearly>(response.Errors));
            return false;
        }
    }
}
