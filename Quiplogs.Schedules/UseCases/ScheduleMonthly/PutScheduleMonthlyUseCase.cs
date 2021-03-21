using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.Schedules.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Quiplogs.Schedules.UseCases.ScheduleMonthly
{
    public class PutScheduleMonthlyUseCase : IPutUseCase<Domain.Entities.ScheduleMonthly, ScheduleMonthlyDto>
    {
        private readonly IBaseRepository<Domain.Entities.ScheduleMonthly, ScheduleMonthlyDto> _baseRepository;

        public PutScheduleMonthlyUseCase(IBaseRepository<Domain.Entities.ScheduleMonthly, ScheduleMonthlyDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(PutRequest<Domain.Entities.ScheduleMonthly> request,
            IOutputPort<PutResponse<Domain.Entities.ScheduleMonthly>> outputPort)
        {
            request.Model.DateNextDue = CalculcateWhenToProcessNext(request.Model);

            var response = await _baseRepository.Put(request.Model);

            if (response.Success)
            {
                outputPort.Handle(new PutResponse<Domain.Entities.ScheduleMonthly>(response.Model, true));
                return true;
            }

            outputPort.Handle(
                new PutResponse<Domain.Entities.ScheduleMonthly>(new[] { new Error("", "Errors Updating Model.") }));
            return false;
        }

        private DateTime? CalculcateWhenToProcessNext(Domain.Entities.ScheduleMonthly model)
        {
            //if no time is specified then we will create one everyday at 12am
            var hour = 0;

            if (model.RecurrenceTime.HasValue)
            {
                hour = model.RecurrenceTime.Value.Hour;
            }

            var dateWithMonthsAdded = DateTime.Today.AddMonths(model.RecurEvery);
            return new DateTime(dateWithMonthsAdded.Year, dateWithMonthsAdded.Month, model.RecurrenceDay).AddHours(hour);
        }
    }
}
