namespace WebApi.Configurations;

public class CorsConfigModel
{
    public string[]? AllowedUrl { get; set; }
}
public static class CorsConfiguration
{
    public static readonly string CorsPolicyName = "app-cors";
    public static IServiceCollection AddCorsService(this IServiceCollection services, IConfiguration config)
    {
        var corsModel = new CorsConfigModel();
        config.GetSection("CorsConfig").Bind(corsModel);
        services.AddSingleton(corsModel);

        services.AddCors(options
      => options.AddPolicy(name: CorsConfiguration.CorsPolicyName, corsBuilder =>
       corsBuilder.WithOrigins(corsModel.AllowedUrl!)
       .AllowAnyHeader()
       .AllowAnyMethod()
        .AllowCredentials()));


        return services;

    }
}
