using Quiplogs.Core.Domain.Entities;
using System;

namespace Quiplogs.Schedules.Domain.Entities
{
    public class ScheduleTime : BaseEntity
    {
        public int RecurEvery { get; set; }
        
        public DateTime? RecurrenceTime { get; set; }

        public DateTime StartDate { get; set; }
    }
}
