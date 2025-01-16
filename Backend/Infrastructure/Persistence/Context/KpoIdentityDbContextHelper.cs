using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;
public static class AppIdentityDbContextHelper
    {
        public static AppIdentityDbContext CreateDbContext(string connectionString)
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<AppIdentityDbContext>();
            AddDbContextSettings(connectionString,optionsBuilder);
            return new AppIdentityDbContext(optionsBuilder.Options);
        }

    public static void AddDbContextSettings(string? connectionString, DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString).UseSnakeCaseNamingConvention(); 
    }
}
