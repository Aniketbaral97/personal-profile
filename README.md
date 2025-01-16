# personal-profile

### Migration

dotnet ef migrations add Initial -o Persistence/Context/Migrations/AppDbContexts -c AppDbContext --startup-project WebApi  --project Infrastructure/

dotnet ef migrations script -c AppDbContext --project WebApi


dotnet ef migrations add Initial -o Persistence/Context/Migrations/AppIdentityDbContexts -c AppIdentityDbContext --startup-project WebApi  --project Infrastructure/

dotnet ef migrations script -c AppIdentityDbContext --project WebApi