using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Experiences;

namespace Application.Interfaces;

public interface IExperienceRepository
{
    public Task<int> AddExperienceAsync(CreateManyExperienceDto experiences);
    public Task<int> UpdateExperienceAsync(UpdateExperienceDto experience);
    public Task<int> DeleteExperienceAsync(Guid id);
    public Task<int> DeleteExperienceByInfoIdAsync(Guid infoId);
    public Task<GetManyExperienceDto> GetExperiencesByInfoIdAsync(Guid infoId);
}
