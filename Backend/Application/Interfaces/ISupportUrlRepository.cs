using Application.DTOs.SupportUrls;

namespace Application.Interfaces;

public interface ISupportUrlRepository
{
    public Task<int> AddSupportUrlAsync(CreateManySupportUrlDto supportUrls);
    public Task<int> UpdateSupportUrlAsync(UpdateSupportUrlDto supportUrl);
    public Task<int> DeleteSupportUrlAsync(Guid id);
    public Task<int> DeleteSupportUrlByInfoIdAsync(Guid infoId);
    public Task<GetManySupportUrlDto> GetSupportUrlsByInfoIdAsync(Guid infoId);
}
