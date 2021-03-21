using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.Schedules.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Quiplogs.Schedules.UseCases.ScheduleWeekly
{
    public class PutScheduleWeeklyUseCase : IPutUseCase<Domain.Entities.ScheduleWeekly, ScheduleWeeklyDto>
    {
        private readonly IBaseRepository<Domain.Entities.ScheduleWeekly, ScheduleWeeklyDto> _baseRepository;

        public PutScheduleWeeklyUseCase(
            IBaseRepository<Domain.Entities.ScheduleWeekly, ScheduleWeeklyDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(PutRequest<Domain.Entities.ScheduleWeekly> request,
            IOutputPort<PutResponse<Domain.Entities.ScheduleWeekly>> outputPort)
        {
            request.Model.DateNextDue = CalculcateWhenToProcessNext(request.Model);

            var response = await _baseRepository.Put(request.Model);

            if (response.Success)
            {
                outputPort.Handle(new PutResponse<Domain.Entities.ScheduleWeekly>(response.Model, true));
                return true;
            }

            outputPort.Handle(
                new PutResponse<Domain.Entities.ScheduleWeekly>(new[] {new Error("", "Errors Updating Model.")}));
            return false;
        }

        private DateTime? CalculcateWhenToProcessNext(Domain.Entities.ScheduleWeekly model)
        {
            //if no time is specified then we will create one everyday at 12am
            var hour = 0;

            if (model.RecurrenceTime.HasValue)
            {
                hour = model.RecurrenceTime.Value.Hour;
            }
            var nextProcessDay = DetermineNextWorkDay(model);
            if (nextProcessDay == 0 || model.RecurEvery > 1)
            {
                nextProcessDay += model.RecurEvery * 7;
            }

            return DateTime.Today.AddDays(nextProcessDay).AddHours(hour);
        }

        private int DetermineNextWorkDay(Domain.Entities.ScheduleWeekly model)
        {
            var currentDayOfWeek = DateTime.Today;
            var currentDayOfWeekInt = (int)currentDayOfWeek.DayOfWeek;
            var response = 0;

            if (model.Monday)
            {
                response = GetNextWeekday(currentDayOfWeek, DayOfWeek.Monday);
                if (currentDayOfWeekInt >= response)
                    return response;
            }

            if (model.Tuesday)
            {
                response = GetNextWeekday(currentDayOfWeek, DayOfWeek.Tuesday);
                if (currentDayOfWeekInt >= response)
                    return response;
            }

            if (model.Wednesday)
            {
                response = GetNextWeekday(currentDayOfWeek, DayOfWeek.Wednesday);
                if (currentDayOfWeekInt >= response)
                    return response;
            }

            if (model.Thursday)
            {
                response = GetNextWeekday(currentDayOfWeek, DayOfWeek.Thursday);
                if (currentDayOfWeekInt >= response)
                    return response;
            }

            if (model.Friday)
            {
                response = GetNextWeekday(currentDayOfWeek, DayOfWeek.Friday);
                if (currentDayOfWeekInt >= response)
                    return response;
            }

            if (model.Saturday)
            {
                response = GetNextWeekday(currentDayOfWeek, DayOfWeek.Saturday);
                if (currentDayOfWeekInt >= response)
                    return response;
            }

            if (model.Sunday)
            {
                response = GetNextWeekday(currentDayOfWeek, DayOfWeek.Sunday);
                if (currentDayOfWeekInt >= response)
                    return response;
            }

            return response;
        }

        private int GetNextWeekday(DateTime start, DayOfWeek day)
        {
            return ((int)day - (int)start.DayOfWeek + 7) % 7;
        }
    }
}
