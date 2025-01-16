
using Application.DTOs.SupportUrls;
using Application.Exceptions;
using Application.Interfaces;
using Application.Services.Common;
using Application.Services.Experiences.Validators;
using Application.Services.SupportUrls.Validators;

namespace Application.Services.SupportedUrls;

public class SupportUrlService : ISupportUrlService
{
    private readonly ISupportUrlRepository _supportUrlRepository;

    public SupportUrlService(ISupportUrlRepository supportUrlRepository)
    {
        _supportUrlRepository = supportUrlRepository;
    }

    public async Task<int> AddSupportUrlAsync(CreateManySupportUrlDto supportUrls)
    {
        CreateManySupportValidator validator = new();
        ValidationHelper.Validate(await validator.ValidateAsync(supportUrls));
        if(supportUrls == null || supportUrls.SupportUrls.Count == 0)
        {
            throw new CommandExecutionException("SupportUrls cannot be null or empty");
        }

        return await _supportUrlRepository.AddSupportUrlAsync(supportUrls);
    }

    public async Task<int> DeleteSupportUrlAsync(Guid id)
    {
        return await _supportUrlRepository.DeleteSupportUrlAsync(id);
    }

    public async Task<int> DeleteSupportUrlByInfoIdAsync(Guid infoId)
    {
        return await _supportUrlRepository.DeleteSupportUrlByInfoIdAsync(infoId);
    }

    public async Task<GetManySupportUrlDto> GetSupportUrlsByInfoIdAsync(Guid infoId)
    {
        return await _supportUrlRepository.GetSupportUrlsByInfoIdAsync(infoId);
    }

    public async Task<int> UpdateSupportUrlAsync(UpdateSupportUrlDto supportUrl)
    {
        UpdateSupportUrlValidator validator = new();
        ValidationHelper.Validate(await validator.ValidateAsync(supportUrl));
        return await _supportUrlRepository.UpdateSupportUrlAsync(supportUrl);
    }
}
