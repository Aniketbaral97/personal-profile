using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

public static class DependencyInjection
{

    public static IServiceCollection ConfigureAppInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    ){
        services.AddScoped<IPersonalInfoRepository, PersonalInfoRepository>();
        services.AddScoped<IEducationRepository, EducationRepository>();
        services.AddScoped<IExperienceRepository, ExperienceRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddScoped<ISupportUrlRepository, SupportUrlRepository>();

        return services;
    }
    public static IServiceCollection AddAppDbContextAndIdentity(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<AppDbContext>(option =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            option.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
            //AppDbContextHelper.AddDbContextSettings(configuration.GetConnectionString("DefaultConnection"), option);
        });
        services
            .AddDbContext<AppIdentityDbContext>(option =>
            {
                option
                    .UseNpgsql(configuration.GetConnectionString("IdentityConnection"))
                    .UseSnakeCaseNamingConvention();
#if DEBUG
                Console.WriteLine("Mode=Debug");
#endif
            })
            .AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Lockout.AllowedForNewUsers = false;
            })
            .AddSignInManager()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<AppIdentityDbContext>();
        return services;
    }

    public static IServiceCollection AddKpoDataServicesAndRepositories(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var settings = new ConnectionSettings
        {
            IdentityConnection = configuration.GetConnectionString("IdentityConnection")!,
            DefaultConnection = configuration.GetConnectionString("DefaultConnection")!
        };
        services.AddSingleton(settings);
        return services;
    }
    public class ConnectionSettings
    {
        public string IdentityConnection {get; set;}="";
        public string DefaultConnection {get; set;}="";
    }
}
