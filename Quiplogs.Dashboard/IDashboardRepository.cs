using Quiplogs.Dashboard.StoredProcedureModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiplogs.Dashboard
{
    public interface IDashboardRepository
    {
        Task<List<WorkOrdersCompletedByDayForWeek>> GetDashboardData(AnalyticsRequest request);
    }
}
