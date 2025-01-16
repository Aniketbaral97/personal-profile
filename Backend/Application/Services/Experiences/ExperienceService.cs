using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Experiences;
using Application.Exceptions;
using Application.Interfaces;
using Application.Services.Common;
using Application.Services.Experiences.Validators;

namespace Application.Services.Experiences;

public class ExperienceService : IExperienceService
{
    private readonly IExperienceRepository _experienceRepository;

    public ExperienceService(IExperienceRepository experienceRepository)
    {
        _experienceRepository = experienceRepository;
    }

    public async Task<int> AddExperienceAsync(CreateManyExperienceDto experiences)
    {
        CreateManyExperienceValidator validator = new();
        ValidationHelper.Validate(await validator.ValidateAsync(experiences));
        if (experiences == null || experiences.Experiences.Count == 0) throw new CommandExecutionException("Experiences cannot be null or empty");
        return await _experienceRepository.AddExperienceAsync(experiences);
    }

    public async Task<int> DeleteExperienceAsync(Guid id)
    {
        return await _experienceRepository.DeleteExperienceAsync(id);
    }

    public async Task<int> DeleteExperienceByInfoIdAsync(Guid infoId)
    {
        return await _experienceRepository.DeleteExperienceByInfoIdAsync(infoId);
    }

    public async Task<GetManyExperienceDto> GetExperiencesByInfoIdAsync(Guid infoId)
    {
        return await _experienceRepository.GetExperiencesByInfoIdAsync(infoId);
    }

    public async Task<int> UpdateExperienceAsync(UpdateExperienceDto experience)
    {
        UpdateExperienceValidator validator = new();
        ValidationHelper.Validate(await validator.ValidateAsync(experience));
        return await _experienceRepository.UpdateExperienceAsync(experience);
    }
}
