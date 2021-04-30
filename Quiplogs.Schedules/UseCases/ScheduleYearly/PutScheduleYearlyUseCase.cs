using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.Schedules.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Quiplogs.Schedules.UseCases.ScheduleYearly
{
    public class PutScheduleYearlyUseCase : IPutUseCase<Domain.Entities.ScheduleYearly, ScheduleYearlyDto>
    {
        private readonly IBaseRepository<Domain.Entities.ScheduleYearly, ScheduleYearlyDto> _baseRepository;

        public PutScheduleYearlyUseCase(
            IBaseRepository<Domain.Entities.ScheduleYearly, ScheduleYearlyDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(PutRequest<Domain.Entities.ScheduleYearly> request,
            IOutputPort<PutResponse<Domain.Entities.ScheduleYearly>> outputPort)
        {
            request.Model.DateNextDue = CalculcateWhenToProcessNext(request.Model);

            var response = await _baseRepository.Put(request.Model);

            if (response.Success)
            {
                outputPort.Handle(new PutResponse<Domain.Entities.ScheduleYearly>(response.Model, true));
                return true;
            }

            outputPort.Handle(
                new PutResponse<Domain.Entities.ScheduleYearly>(response.Errors));
            return false;
        }

        private DateTime? CalculcateWhenToProcessNext(Domain.Entities.ScheduleYearly model)
        {
            //if no time is specified then we will create one everyday at 12am
            var hour = 0;

            if (model.RecurrenceTime.HasValue)
            {
                hour = model.RecurrenceTime.Value.Hour;
            }

            var dateWithYearsAdded = DateTime.Today.AddMonths(model.RecurEvery);
            if (model.StartDate.HasValue)
            {
                dateWithYearsAdded = model.StartDate.Value.AddDays(model.RecurEvery).AddHours(hour);
            }
            return new DateTime(dateWithYearsAdded.Year, model.RecurrenceMonth, model.RecurrenceDay).AddHours(hour);
        }
    }
}
