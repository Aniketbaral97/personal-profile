using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Educations;
using Application.Exceptions;
using Application.Interfaces;
using Application.Services.Common;
using Application.Services.Educations.Validators;

namespace Application.Services.Educations;

public class EducationService : IEducationService
{
    private readonly IEducationRepository _educationRepository;

    public EducationService(IEducationRepository educationRepository)
    {
        _educationRepository = educationRepository;
    }

    public async Task<int> AddEducationAsync(CreateManyEducationDto educations)
    {
        CreateManyEducationValidator validator = new();
        ValidationHelper.Validate(await validator.ValidateAsync(educations));
        if(educations == null || educations.Educations.Count == 0)
        {
            throw new CommandExecutionException("Educations cannot be null or empty");
        }

        return await _educationRepository.AddEducationAsync(educations);
    }

    public async Task<int> DeleteEducationAsync(Guid id)
    {
        return await _educationRepository.DeleteEducationAsync(id);
    }

    public Task<int> DeleteEducationByInfoIdAsync(Guid infoId)
    {
        return _educationRepository.DeleteEducationByInfoIdAsync(infoId);
    }

    public Task<GetManyEducationDto> GetEducationsByInfoIdAsync(Guid infoId)
    {
        return _educationRepository.GetEducationsByInfoIdAsync(infoId);
    }

    public async Task<int> UpdateEducationAsync(UpdateEducationDto education)
    {
        UpdateEducationValidator validator = new();
        ValidationHelper.Validate(await validator.ValidateAsync(education));
       return await _educationRepository.UpdateEducationAsync(education);
    }
}
