using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.SupportUrls;

namespace Application.Interfaces;

public interface ISupportUrlService
{
    public Task<int> AddSupportUrlAsync(CreateManySupportUrlDto supportUrls);
    public Task<int> UpdateSupportUrlAsync(UpdateSupportUrlDto supportUrl);
    public Task<int> DeleteSupportUrlAsync(Guid id);
    public Task<int> DeleteSupportUrlByInfoIdAsync(Guid infoId);
    public Task<GetManySupportUrlDto> GetSupportUrlsByInfoIdAsync(Guid infoId);
}
