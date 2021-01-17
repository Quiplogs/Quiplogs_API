using System;

namespace Quiplogs.PMSchedule.Data.Entities
{
    public abstract class PlannedMaintenanceScheduleTime : PlannedMaintenanceSchedule
    {
        //Recurs every X
        public int RecurEvery { get; set; }

        //At what time should it recur
        public DateTime? RecurrenceTime { get; set; }

        public DateTime StartDate { get; set; }
    }
}
