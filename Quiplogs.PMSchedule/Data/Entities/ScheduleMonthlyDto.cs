namespace Quiplogs.PMSchedule.Data.Entities
{
    public class ScheduleMonthlyDto : ScheduleTime
    {
        //On which day should it recur
        public int RecurrenceDay { get; set; }
    }
}
