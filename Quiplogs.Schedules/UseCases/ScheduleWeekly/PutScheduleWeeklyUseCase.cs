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
                new PutResponse<Domain.Entities.ScheduleWeekly>(response.Errors));
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

            if (model.StartDate.HasValue)
            {
                return model.StartDate.Value.AddDays(GetNextWeekday(model)).AddHours(hour);
            }

            return DateTime.Today.AddDays(GetNextWeekday(model)).AddHours(hour);
        }

        private int GetNextWeekday(Domain.Entities.ScheduleWeekly model)
        {
            var selectedDays = new bool[7];
            selectedDays[0] = model.Monday;
            selectedDays[1] = model.Tuesday;
            selectedDays[2] = model.Wednesday;
            selectedDays[3] = model.Thursday;
            selectedDays[4] = model.Friday;
            selectedDays[5] = model.Saturday;
            selectedDays[6] = model.Sunday;

            var currentDay = model.StartDate.HasValue ? (int)model.StartDate.Value.DayOfWeek : (int)DateTime.Today.DayOfWeek;
            var daysTillNextProcess = 1;
            for (int i = currentDay; i < selectedDays.Length; i++)
            {
                if (!selectedDays[i])
                {
                    daysTillNextProcess++;
                }

                if (i == 6)
                {
                    for (int nextWeek = 0; i < selectedDays.Length; i++)
                    {
                        if (!selectedDays[nextWeek])
                        {
                            daysTillNextProcess++;
                        }
                    }

                    if (model.RecurEvery > 1)
                    {
                        daysTillNextProcess += (model.RecurEvery - 1) * 7;
                    }
                }
            }

            return daysTillNextProcess;
        }
    }
}
