using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.SqlContext
{
    public class DbContextFactory : DesignTimeDbContextFactoryBase<SqlDbContext>
    {
        protected override SqlDbContext CreateNewInstance(DbContextOptions<SqlDbContext> options)
        {
            return new SqlDbContext(options);
        }
    }
}
