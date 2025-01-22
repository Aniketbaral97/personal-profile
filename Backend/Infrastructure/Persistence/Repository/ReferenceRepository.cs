using Application.DTOs.References;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository;

public class ReferenceRepository : IReferenceRepository
{
    private readonly AppDbContext _context;

    public ReferenceRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<int> AddReferenceAsync(CreateManyReferenceDto request)
    {
        if(request == null || request.References.Count == 0) return 0;

        var entities = request.References.Select(x => new Reference()
        {
            PersonalInfoId = request.PersonalInfoId,
            Description = x.Description,
            Name =x.Name,
            Position=x.Position,
            WorkPlace=x.WorkPlace,
            ContactInfo=x.ContactInfo,
            Email=x.Email,

        }).ToList();

        await _context.References.AddRangeAsync(entities);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteReferenceAsync(Guid id)
    {
        return await _context.References.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task<int> DeleteReferenceByInfoIdAsync(Guid infoId)
    {
        return await _context.References.Where(x => x.PersonalInfoId == infoId).ExecuteDeleteAsync();
    }

    public async Task<GetManyReferenceDto> GetReferencesByInfoIdAsync(Guid infoId)
    {
        var response = new GetManyReferenceDto
        {
            References = await _context.References.Where(x => x.PersonalInfoId == infoId).Select(x => new ReferenceDto()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                Position = x.Position,
                WorkPlace = x.WorkPlace,
                ContactInfo = x.ContactInfo,
                Email = x.Email,
            }).ToListAsync()
        };
        return response;
    }

    public async Task<int> UpdateReferenceAsync(UpdateReferenceDto Reference)
    {
        return await _context.References.Where(x => x.Id == Reference.Id)
        .ExecuteUpdateAsync(x => x.SetProperty(x => x.Name, Reference.Name)
        .SetProperty(x => x.Email, Reference.Email)
        .SetProperty(x => x.ContactInfo, Reference.ContactInfo)
        .SetProperty(x => x.Description, Reference.Description)
        .SetProperty(x => x.Position, Reference.Position)
        .SetProperty(x => x.WorkPlace, Reference.WorkPlace));
    }
}
