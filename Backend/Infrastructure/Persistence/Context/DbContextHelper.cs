using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;
public static class AppDbContextHelper
{
     public static AppDbContext CreateDbContext(string connectionString)
     {

          var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
          AddDbContextSettings(connectionString, optionsBuilder);
          return new AppDbContext(optionsBuilder.Options);
     }

     public static void AddDbContextSettings(string? connectionString, DbContextOptionsBuilder optionsBuilder)
     {
          optionsBuilder.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
     }
}
