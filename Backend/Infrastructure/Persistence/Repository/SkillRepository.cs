using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Skills;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository;

public class SkillRepository : ISkillRepository
{
    private readonly AppDbContext _context;

    public SkillRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddSkillAsync(CreateManySkillDto skills)
    {
        if (skills == null || skills.Skills.Count == 0) return 0;
        var entities = skills.Skills.Select(x => new Skills(){
            PersonalInfoId = skills.PersonalInfoId,
            Type = x.Type,
            Skill = x.Skill,
            Level = x.Level,
        }).ToList();

        await _context.Skills.AddRangeAsync(entities);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteSkillAsync(Guid id)
    {
        return await _context.Skills.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task<int> DeleteSkillByInfoIdAsync(Guid infoId)
    {
        return await _context.Skills.Where(x => x.PersonalInfoId == infoId).ExecuteDeleteAsync();
    }

    public async Task<GetManySkillDto> GetSkillsByInfoIdAsync(Guid infoId)
    {
        var response = new GetManySkillDto();
        response.Skills = await _context.Skills.Where(x => x.PersonalInfoId == infoId).Select(x => new SkillDto()
        {
            Id = x.Id,
            Type = x.Type,
            Skill = x.Skill,
            Level = x.Level,
        }).ToListAsync();
        return response;
    }

    public async Task<int> UpdateSkillAsync(UpdateSkillDto skill)
    {
        return await _context.Skills.Where(x => x.Id == skill.Id)
        .ExecuteUpdateAsync(x => x.SetProperty(x => x.Type, skill.Type)
        .SetProperty(x => x.Skill, skill.Skill)
        .SetProperty(x => x.Level, skill.Level));
    }
}
