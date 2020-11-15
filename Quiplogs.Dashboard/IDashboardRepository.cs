using System.Collections.Generic;

namespace Quiplogs.Dashboard
{
    public interface IDashboardRepository
    {
        IEnumerable<dynamic> GetDashboardData(AnalyticsRequest request);
    }
}
