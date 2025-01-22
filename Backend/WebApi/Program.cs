using Microsoft.OpenApi.Models;
using Application.DependencyInjection;
using Infrastructure.Persistence;
using WebApi.EndPoints;
using WebApi.Configurations;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddCorsService(builder.Configuration);
builder.Services.AddScoped<HttpClient>();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "CMS API", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddAppDbContextAndIdentity(builder.Configuration);
builder.Services.AddAppJwtConfiguration(builder.Configuration);
builder.Services.AddAppAuthorization();

builder.Services.ConfigureAppAplication();
builder.Services.ConfigureAppInfrastructure();
builder.Services.AddKpoDataServicesAndRepositories(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("app-cors");
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.AddAppEndPoints();
app.Run();
