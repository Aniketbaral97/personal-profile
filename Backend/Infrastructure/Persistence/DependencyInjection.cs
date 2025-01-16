using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

public static class DependencyInjection
{
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
}
