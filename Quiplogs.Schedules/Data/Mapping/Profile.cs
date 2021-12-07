using AutoMapper;
using Quiplogs.Schedules.Data.Entities;
using Quiplogs.Schedules.Domain.Entities;

namespace Quiplogs.Schedules.Data.Mapping
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<ScheduleCustom, ScheduleCustomDto>();
            CreateMap<ScheduleCustomDto, ScheduleCustom>();
            CreateMap<ScheduleDaily, ScheduleDailyDto>();
            CreateMap<ScheduleDailyDto, ScheduleDaily>();
            CreateMap<ScheduleWeekly, ScheduleWeeklyDto>();
            CreateMap<ScheduleWeeklyDto, ScheduleWeekly>();
            CreateMap<ScheduleMonthly, ScheduleMonthlyDto>();
            CreateMap<ScheduleMonthlyDto, ScheduleMonthly>();
            CreateMap<ScheduleYearly, ScheduleYearlyDto>();
            CreateMap<ScheduleYearlyDto, ScheduleYearly>();
        }
    }
}
