using System;
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
    public class PutScheduleDailyUseCase : IPutUseCase<Domain.Entities.ScheduleDaily, ScheduleDailyDto>
    {
        private readonly IBaseRepository<Domain.Entities.ScheduleDaily, ScheduleDailyDto> _baseRepository;

        public PutScheduleDailyUseCase(IBaseRepository<Domain.Entities.ScheduleDaily, ScheduleDailyDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(PutRequest<Domain.Entities.ScheduleDaily> request,
            IOutputPort<PutResponse<Domain.Entities.ScheduleDaily>> outputPort)
        {
            request.Model.DateNextDue = CalculcateWhenToProcessNext(request.Model);

            var response = await _baseRepository.Put(request.Model);

            if (response.Success)
            {
                outputPort.Handle(new PutResponse<Domain.Entities.ScheduleDaily>(response.Model, true));
                return true;
            }

            outputPort.Handle(
                new PutResponse<Domain.Entities.ScheduleDaily>(response.Errors));
            return false;
        }

        private DateTime? CalculcateWhenToProcessNext(Domain.Entities.ScheduleDaily model)
        {
            //if no time is specified then we will create one everyday at 12am
            var hour = 0;

            if (model.RecurrenceTime.HasValue)
            {
                hour = model.RecurrenceTime.Value.Hour;
            }

            if (model.StartDate.HasValue)
            {
                return model.StartDate.Value.AddDays(model.RecurEvery).AddHours(hour);
            }

            return DateTime.Today.AddDays(model.RecurEvery).AddHours(hour);
        }
    }
}
