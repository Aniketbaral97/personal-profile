using Application.Interfaces;
using Application.Services.Educations;
using Application.Services.Experiences;
using Application.Services.Identity;
using Application.Services.PersonalInfo;
using Application.Services.References;
using Application.Services.Skills.Validators;
using Application.Services.SupportedUrls;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection;

public static class ApplicationConfiguration
{
    public static IServiceCollection ConfigureAppAplication(
        this IServiceCollection services
    ){
        services.AddScoped<IPersonalInfoService, PersonalInfoService>();
        services.AddScoped<IEducationService, EducationService>();
        services.AddScoped<IExperienceService, ExperienceService>();
        services.AddScoped<ISkillService, SkillService>();
        services.AddScoped<ISupportUrlService, SupportUrlService>();
        services.AddScoped<IReferenceService, ReferenceService>();
        services.AddScoped<IIdentityService, IdentityService>();

        return services;
    }
}
