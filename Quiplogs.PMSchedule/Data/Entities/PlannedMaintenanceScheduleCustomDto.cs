using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.PMSchedule.Data.Entities
{
    public class PlannedMaintenanceScheduleCustomDto : PlannedMaintenanceSchedule
    {
        [Column(TypeName = "decimal(18, 6)")]
        public decimal RecurEvery { get; set; }

        public decimal CycleNextDue { get; set; }

        public decimal StartingAt { get; set; }
    }
}
