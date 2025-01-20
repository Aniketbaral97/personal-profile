using Domain.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.Repository;

public static class Policies{
        public static IServiceCollection AppAuthorization(this IServiceCollection service)
        {
            service.AddAuthorizationBuilder()
                .AddPolicy("Admin", policy =>policy.RequireAssertion(context=>context.User.HasClaim(c=>c.Value ==AvailableClaims.Admin.ToString())));
            return service;
        }
    }