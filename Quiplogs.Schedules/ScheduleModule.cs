using Autofac;
using Quiplogs.Schedules.UseCases.ScheduleCustom;
using Quiplogs.Schedules.UseCases.ScheduleDaily;
using Quiplogs.Schedules.UseCases.ScheduleMonthly;
using Quiplogs.Schedules.UseCases.ScheduleWeekly;
using Quiplogs.Schedules.UseCases.ScheduleYearly;

namespace Quiplogs.Schedules
{
    public class ScheduleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ListScheduleCustomUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<PutScheduleCustomUseCase>().InstancePerLifetimeScope();

            builder.RegisterType<ListScheduleDailyUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<PutScheduleDailyUseCase>().InstancePerLifetimeScope();

            builder.RegisterType<ListScheduleWeeklyUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<PutScheduleWeeklyUseCase>().InstancePerLifetimeScope();

            builder.RegisterType<ListScheduleMonthlyUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<PutScheduleMonthlyUseCase>().InstancePerLifetimeScope();

            builder.RegisterType<ListScheduleYearlyUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<PutScheduleYearlyUseCase>().InstancePerLifetimeScope();
        }
    }
}
