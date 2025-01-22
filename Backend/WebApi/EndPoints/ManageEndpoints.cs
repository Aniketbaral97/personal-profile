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
        routes.MapReferenceApi();
        return routes;
    }
}
