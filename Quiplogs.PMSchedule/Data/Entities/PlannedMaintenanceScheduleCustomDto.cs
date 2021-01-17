namespace Quiplogs.PMSchedule.Data.Entities
{
    public class PlannedMaintenanceScheduleCustomDto : PlannedMaintenanceSchedule
    {
        public int RecurEvery { get; set; }

        public int StartingAt { get; set; }
    }
}
