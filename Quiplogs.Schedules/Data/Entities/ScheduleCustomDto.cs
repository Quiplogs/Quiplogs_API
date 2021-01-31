using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.Schedules.Data.Entities
{
    public class ScheduleCustomDto : Schedule
    {
        [Column(TypeName = "decimal(18, 6)")]
        public decimal RecurEvery { get; set; }

        public decimal CycleNextDue { get; set; }

        public decimal StartingAt { get; set; }
    }
}
