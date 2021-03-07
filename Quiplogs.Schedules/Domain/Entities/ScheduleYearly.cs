namespace Quiplogs.Schedules.Domain.Entities
{
    public class ScheduleYearly : ScheduleTime
    {
        public int RecurrenceMonth { get; set; }
        
        public int RecurrenceDay { get; set; }
    }
}
