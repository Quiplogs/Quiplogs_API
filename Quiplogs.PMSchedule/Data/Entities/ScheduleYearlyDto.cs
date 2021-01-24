namespace Quiplogs.PMSchedule.Data.Entities
{
    public class ScheduleYearlyDto : ScheduleTime
    {
        //On which month should it recur
        public int RecurrenceMonth { get; set; }

        //On which day should it recur
        public int RecurrenceDay { get; set; }
    }
}
