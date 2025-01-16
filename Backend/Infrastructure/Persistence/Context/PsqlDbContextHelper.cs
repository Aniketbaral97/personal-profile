using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Context;
// public static class AppMysqlDbContextHelper
// {
//     public static AppDbContext CreateDbContext(string connectionString)
//      {
//           var serverVersion = new Version(10, 1, 47);
//           var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
//           optionsBuilder.UseNpgsql(connectionString, new (serverVersion));

//           return new AppDbContext(optionsBuilder.Options);
//      }
        
// }
// public static class AppMysqlIdentityDbContextHelper
// {
//     public static AppIdentityDbContext CreateDbContext(string connectionString)
//      {
//           var serverVersion = new Version(10, 1, 47);
//           var optionsBuilder = new DbContextOptionsBuilder<AppIdentityDbContext>();
//           optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(serverVersion));

//           return new AppIdentityDbContext(optionsBuilder.Options);
//      }
        
// }