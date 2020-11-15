using Api.Infrastructure.SqlContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Quiplogs.Dashboard;
using System.Collections.Generic;
using System.Dynamic;

namespace Quiplogs.Infrastructure.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly SqlDbContext _context;

        public DashboardRepository(SqlDbContext context)
        {
            _context = context;
        }

        public IEnumerable<dynamic> GetDashboardData(AnalyticsRequest request)
        {
            if (request.LocationId == null)
            {
                return GetDynamicResult($"EXEC {request.StoredProcedure} @CompanyId ", new SqlParameter("@CompanyId", request.CompanyId));
            }
            else
            {
                return GetDynamicResult($"EXEC {request.StoredProcedure} @CompanyId, @LocationId ", new SqlParameter("@CompanyId", request.CompanyId), new SqlParameter("@LocationId", request.LocationId));
            }
        }

        public IEnumerable<dynamic> GetDynamicResult(string commandText, params SqlParameter[] parameters)
        {
            // Get the connection from DbContext
            var connection = _context.Database.GetDbConnection();

            // Open the connection if isn't open
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = commandText;
                command.Connection = connection;

                if (parameters?.Length > 0)
                {
                    foreach (var parameter in parameters)
                    {
                        if (!command.Parameters.Contains(parameter))
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                }

                using (var dataReader = command.ExecuteReader())
                {
                    // List for column names
                    var names = new List<string>();

                    if (dataReader.HasRows)
                    {
                        // Add column names to list
                        for (var i = 0; i < dataReader.VisibleFieldCount; i++)
                        {
                            names.Add(dataReader.GetName(i));
                        }

                        while (dataReader.Read())
                        {
                            // Create the dynamic result for each row
                            var result = new ExpandoObject() as IDictionary<string, object>;

                            foreach (var name in names)
                            {
                                // Add key-value pair
                                // key = column name
                                // value = column value
                                result.Add(name, dataReader[name]);
                            }

                            yield return result;
                        }
                    }
                }
            }
        }
    }
}
