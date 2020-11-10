using System.Collections.Generic;

namespace Quiplogs.Dashboard
{
    public static class StoredProceduresDashboard
    {
        public static Dictionary<string, string> Procedures = new Dictionary<string, string>
        {
            {"TotalAssets", "Analytics_TotalAssets"},
            {"TotalAssetsInMaintenance", "Analytics_TotalAssetsInMaintenance"},
            {"WorkOrderOpen", "Analytics_WorkOrderOpen"},
            {"WorkOrderPriority", "Analytics_WorkOrderPriority"},
            {"WorkOrdersCompletedByDayForWeek", "Analytics_WorkOrdersCompletedByDayForWeek"},
        };
    }
}
