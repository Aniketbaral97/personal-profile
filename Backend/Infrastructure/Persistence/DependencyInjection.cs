using Application.DTOs.Identity;
using Application.Interfaces;
using Application.Services.Identity;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Persistence;

public static class DependencyInjection
{

    public static IServiceCollection ConfigureAppInfrastructure(
        this IServiceCollection services
    )
    {
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
        });
        services
            .AddDbContext<AppIdentityDbContext>(option =>
            {
                option
                    .UseNpgsql(configuration.GetConnectionString("IdentityConnection"))
                    .UseSnakeCaseNamingConvention();
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


    public static IServiceCollection AddAppJwtConfiguration(this IServiceCollection service, IConfiguration configuration)
    {
        var jwtConfig = new JwtConfig(configuration["Jwt:Key"] ?? string.Empty,
        configuration["Jwt:Issuer"] ?? string.Empty,
        Convert.ToInt32(configuration["Jwt:ExpiresInHour"] ?? string.Empty));
        JwtTokenService tokenService = new(jwtConfig);
        service.AddSingleton(tokenService);
        service.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.SaveToken = true;
            x.RequireHttpsMetadata = false;
            x.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidIssuer = configuration["jwt:Issuer"],
                IssuerSigningKey = tokenService.GetSymmetricSecurityKey()
            };
            x.Events = new JwtBearerEvents()
            {
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers["Token-Expired"] = "true";
                    }
                    System.Console.WriteLine("Token failed ");
                    return Task.CompletedTask;
                }
            };
        });
        return service;

    }
    public static IServiceCollection AddAppAuthorization(this IServiceCollection services)
    {
        return Policies.AppAuthorization(services);
    }
    public class ConnectionSettings
    {
        public string IdentityConnection { get; set; } = "";
        public string DefaultConnection { get; set; } = "";
    }

}
