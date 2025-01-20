using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
namespace WebApi.EndPoints;

public static class ManageEndpoints
{
    public static IEndpointRouteBuilder AddAppEndPoints(this IEndpointRouteBuilder routes)
    {
        routes.MapEducationtApi();
        routes.MapExperienceApi();
        routes.MapPersonalInfoApi();
        routes.MapSkillApi();
        routes.MapSupportUrlApi();
        routes.MapUserAuthApi();
        routes.MapUserEndpoint();
        return routes;
    }
}
