using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.Dashboard.StoredProcedureModels
{
    [NotMapped]
    public class WorkOrdersCompletedByDayForWeek
    {
        public string Date { get; set; }
        public int TotalCompleted { get; set; }
    }
}
