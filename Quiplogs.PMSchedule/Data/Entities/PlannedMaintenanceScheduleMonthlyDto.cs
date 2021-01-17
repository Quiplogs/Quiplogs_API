namespace Quiplogs.PMSchedule.Data.Entities
{
    public class PlannedMaintenanceScheduleMonthlyDto : PlannedMaintenanceScheduleTime
    {
        //On which day should it recur
        public int RecurrenceDay { get; set; }
    }
}
