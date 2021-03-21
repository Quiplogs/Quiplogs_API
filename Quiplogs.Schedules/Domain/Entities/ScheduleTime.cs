using System;

namespace Quiplogs.Schedules.Domain.Entities
{
    public class ScheduleTime : Schedule
    {
        public int RecurEvery { get; set; }
        
        public DateTime? RecurrenceTime { get; set; }

        public DateTime StartDate { get; set; }
    }
}
