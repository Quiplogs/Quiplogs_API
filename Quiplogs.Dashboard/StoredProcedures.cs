using System.Collections.Generic;

namespace Quiplogs.Dashboard
{
    public static class StoredProceduresDashboard
    {
        public static Dictionary<string, string> Procedures = new Dictionary<string, string>
        {
            {"TextHeader", "Analytics_TextHeaderValues"},
            {"WorkOrderOpen", "Analytics_WorkOrderOpenList"},
            {"WorkOrderPlannedVUnplanned", "Analytics_WorkOrderPlannedVUnplanned"},
            {"WorkOrderPriority", "Analytics_WorkOrderPriority"},
            {"WorkOrdersCompletedByDayForWeek", "Analytics_WorkOrdersCompletedByDayForWeek"},
            {"AssetWorkOrders", "Asset_WorkOrderValues" }
        };
    }
}
