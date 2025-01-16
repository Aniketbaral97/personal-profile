using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Skills;
using Application.Exceptions;
using Application.Interfaces;
using Application.Services.Common;

namespace Application.Services.Skills.Validators;

public class SkillService : ISkillService
{
    private readonly ISkillRepository _skillRepository;

    public SkillService(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<int> AddSkillAsync(CreateManySkillDto skills)
    {
        CreateManySkillValidator validator = new();
        ValidationHelper.Validate(await validator.ValidateAsync(skills));
        if(skills == null || skills.Skills.Count == 0)
        {
            throw new CommandExecutionException("Skills cannot be null or empty");
        }

        return await _skillRepository.AddSkillAsync(skills);
    }

    public async Task<int> DeleteSkillAsync(Guid id)
    {
        return await _skillRepository.DeleteSkillAsync(id);
    }

    public async Task<int> DeleteSkillByInfoIdAsync(Guid infoId)
    {
        return await _skillRepository.DeleteSkillByInfoIdAsync(infoId);
    }

    public async Task<GetManySkillDto> GetSkillsByInfoIdAsync(Guid infoId)
    {
        return await _skillRepository.GetSkillsByInfoIdAsync(infoId);
    }

    public async Task<int> UpdateSkillAsync(UpdateSkillDto skill)
    {
        UpdateSkillValidator validator = new();
        ValidationHelper.Validate(await validator.ValidateAsync(skill));
        return await _skillRepository.UpdateSkillAsync(skill);
    }
}
