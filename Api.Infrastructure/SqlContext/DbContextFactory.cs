using Microsoft.EntityFrameworkCore;

namespace Quiplogs.Infrastructure.SqlContext
{
    public class DbContextFactory : DesignTimeDbContextFactoryBase<SqlDbContext>
    {
        protected override SqlDbContext CreateNewInstance(DbContextOptions<SqlDbContext> options)
        {
            return new SqlDbContext(options);
        }
    }
}
