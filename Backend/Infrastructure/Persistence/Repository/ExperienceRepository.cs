using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Experiences;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository;

public class ExperienceRepository : IExperienceRepository
{
    private readonly AppDbContext _context;

    public ExperienceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddExperienceAsync(CreateManyExperienceDto experiences)
    {
        if (experiences == null || experiences.Experiences.Count == 0) return 0;
        var entities = experiences.Experiences.Select(x => new Experience()
        {
            PersonalInfoId = experiences.PersonalInfoId,
            Title = x.Title,
            Company = x.Company,
            Position = x.Position,
            Duration = x.Duration,
            Description = x.Description,
            IsCurrent = x.IsCurrent,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
        }).ToList();

        await _context.Experiences.AddRangeAsync(entities);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteExperienceAsync(Guid id)
    {
        return await _context.Experiences.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task<int> DeleteExperienceByInfoIdAsync(Guid infoId)
    {
        return await _context.Experiences.Where(x => x.PersonalInfoId == infoId).ExecuteDeleteAsync();
    }

    public async Task<GetManyExperienceDto> GetExperiencesByInfoIdAsync(Guid infoId)
    {
        var response = new GetManyExperienceDto();
        response.Experiences = await _context.Experiences.Where(x => x.PersonalInfoId == infoId).Select(x => new ExperienceDto()
        {
            Id = x.Id,
            Title = x.Title,
            Company = x.Company,
            Position = x.Position,
            Duration = x.Duration,
            Description = x.Description,
            IsCurrent = x.IsCurrent,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
        }).ToListAsync();
        return response;
    }

    public async Task<int> UpdateExperienceAsync(UpdateExperienceDto experience)
    {
        return await _context.Experiences.Where(x => x.Id == experience.Id)
        .ExecuteUpdateAsync(x => x.SetProperty(x => x.Title, experience.Title)
        .SetProperty(x => x.Company, experience.Company)
        .SetProperty(x => x.Position, experience.Position)
        .SetProperty(x => x.Duration, experience.Duration)
        .SetProperty(x => x.Description, experience.Description)
        .SetProperty(x => x.IsCurrent, experience.IsCurrent)
        .SetProperty(x => x.StartDate, experience.StartDate)
        .SetProperty(x => x.EndDate, experience.EndDate));
    }
}
