using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Educations;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository;

public class EducationRepository : IEducationRepository
{
    private readonly AppDbContext _context;

    public EducationRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<int> AddEducationAsync(CreateManyEducationDto educations)
    {
        if(educations == null || educations.Educations.Count == 0) return 0;

        var entities = educations.Educations.Select(x => new Education()
        {
            PersonalInfoId = educations.PersonalInfoId,
            Institution = x.Institution,
            Degree = x.Degree,
            Duration = x.Duration,
            Description = x.Description,
            GradingType = x.GradingType,
            IsCurrent = x.IsCurrent,
            Grading = x.Grading,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
        }).ToList();

        await _context.Educations.AddRangeAsync(entities);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteEducationAsync(Guid id)
    {
        return await _context.Educations.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task<int> DeleteEducationByInfoIdAsync(Guid infoId)
    {
        return await _context.Educations.Where(x => x.PersonalInfoId == infoId).ExecuteDeleteAsync();
    }

    public async Task<GetManyEducationDto> GetEducationsByInfoIdAsync(Guid infoId)
    {
        var response = new GetManyEducationDto();
        response.Educations = await _context.Educations.Where(x => x.PersonalInfoId == infoId).Select(x => new EducationDto()
        {
            Id = x.Id,
            Institution = x.Institution,
            Degree = x.Degree,
            Duration = x.Duration,
            Description = x.Description,
            GradingType = x.GradingType,
            Grading = x.Grading,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
            IsCurrent = x.IsCurrent,
        }).ToListAsync();
        return response;
    }

    public async Task<int> UpdateEducationAsync(UpdateEducationDto education)
    {
        return await _context.Educations.Where(x => x.Id == education.Id)
        .ExecuteUpdateAsync(x => x.SetProperty(x => x.Institution, education.Institution)
        .SetProperty(x => x.Degree, education.Degree)
        .SetProperty(x => x.Duration, education.Duration)
        .SetProperty(x => x.Description, education.Description)
        .SetProperty(x => x.GradingType, education.GradingType)
        .SetProperty(x => x.Grading, education.Grading)
        .SetProperty(x => x.IsCurrent, education.IsCurrent)
        .SetProperty(x => x.StartDate, education.StartDate)
        .SetProperty(x => x.EndDate, education.EndDate));
    }
}
