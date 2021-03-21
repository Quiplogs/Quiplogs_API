namespace Quiplogs.Schedules.Domain.Entities
{
    public class ScheduleCustom : Schedule
    {
        public decimal RecurEvery { get; set; }

        public decimal? CycleNextDue { get; set; }

        public decimal StartingAt { get; set; }
    }
}
