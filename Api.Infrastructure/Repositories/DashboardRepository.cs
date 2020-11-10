using Api.Infrastructure.SqlContext;
using Microsoft.EntityFrameworkCore;
using Quiplogs.Dashboard;
using Quiplogs.Dashboard.StoredProcedureModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiplogs.Infrastructure.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly SqlDbContext _context;

        public DashboardRepository(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkOrdersCompletedByDayForWeek>> GetDashboardData(AnalyticsRequest request)
        {
            string sqlString = $"EXEC {request.StoredProcedure} @CompanyId = '{request.CompanyId}', @LocationId = '{request.LocationId}'";

            return await _context.SP_WorkOrdersCompletedByDayForWeek.FromSqlRaw(sqlString).ToListAsync();
        }
    }
}
