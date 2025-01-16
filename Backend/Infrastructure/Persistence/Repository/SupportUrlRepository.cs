using Application.DTOs.SupportUrls;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository;

public class SupportUrlRepository : ISupportUrlRepository
{
    private readonly AppDbContext _context;

    public SupportUrlRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddSupportUrlAsync(CreateManySupportUrlDto supportUrls)
    {
        if(supportUrls == null || supportUrls.SupportUrls.Count == 0) return 0;
        var entities = supportUrls.SupportUrls.Select(x => new SupportUrls(){
            PersonalInfoId = supportUrls.PersonalInfoId,
            Type = x.Type,
            Url = x.Url,
        }).ToList();

        await _context.SupportUrls.AddRangeAsync(entities);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteSupportUrlAsync(Guid id)
    {
        return await _context.SupportUrls.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task<int> DeleteSupportUrlByInfoIdAsync(Guid infoId)
    {
        await _context.SupportUrls.Where(x => x.PersonalInfoId == infoId).ExecuteDeleteAsync();
        return await _context.SaveChangesAsync();
    }

    public async Task<GetManySupportUrlDto> GetSupportUrlsByInfoIdAsync(Guid infoId)
    {
        var response = new GetManySupportUrlDto();
        response.SupportUrls = await _context.SupportUrls.Where(x => x.PersonalInfoId == infoId).Select(x => new SupportUrlDto()
        {
            Id = x.Id,
            Type = x.Type,
            Url = x.Url,
        }).ToListAsync();
        return response;
    }

    public async Task<int> UpdateSupportUrlAsync(UpdateSupportUrlDto supportUrl)
    {
        return await _context.SupportUrls.Where(x => x.Id == supportUrl.Id)
        .ExecuteUpdateAsync(x => x.SetProperty(x => x.Type, supportUrl.Type)
        .SetProperty(x => x.Url, supportUrl.Url));
    }
}
